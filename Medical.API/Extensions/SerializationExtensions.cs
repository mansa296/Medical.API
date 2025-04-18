﻿using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace Medical.API.Extensions
{
    public static class SerializationExtensions
    {
        public static byte[] ToByteArray(this object objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                return null;
            }

            return Encoding.Default.GetBytes(JsonConvert.SerializeObject(objectToSerialize));
        }

        public static T FromByteArray<T>(this byte[] arrayToDeserialize) where T : class
        {
            if (arrayToDeserialize is null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(arrayToDeserialize));
        }
    }
    public static class DistributedCacheExtensions
    {
        public async static Task<T> GetCachedValueAsyn<T>(this IDistributedCache cache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await cache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }

        public async static Task SetCachedValueAsync<T>(this IDistributedCache cache, string key, T value, CancellationToken token = default(CancellationToken))
        {
            await cache.SetAsync(key, value.ToByteArray(), token);
        }
    }
    public class ClientStatistics
    {
        public DateTime LastSuccessfulResponseTime { get; set; }
        public int NumberofRequestsCompletedSuccessfully { get; set; }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class LimitRequest : Attribute
    {
        public int TimeWindow { get; set; }
        public int MaxRequests { get; set; }
    }
}
