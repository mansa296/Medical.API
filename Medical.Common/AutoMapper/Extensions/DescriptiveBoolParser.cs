using AutoMapper;
using Medical.Common.AutoMapper.ValueConverters;
using System.Linq.Expressions;

namespace Medical.Common.AutoMapper.Extensions
{
    /// <summary>
    /// The auto mapper extensions class
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// The converter
        /// </summary>
        private static readonly DescriptiveBoolConverter _converter = new();
        /// <summary>
        /// Parses the descriptive bool using the specified conf
        /// </summary>
        /// <typeparam name="TSource">The source</typeparam>
        /// <typeparam name="TDestination">The destination</typeparam>
        /// <param name="conf">The conf</param>
        /// <param name="sourceMember">The source member</param>
        public static void ParseDescriptiveBool<TSource, TDestination>(
            this IMemberConfigurationExpression<TSource, TDestination, bool> conf,
            Expression<Func<TSource, string>> sourceMember)
        {
            conf.ConvertUsing(_converter, sourceMember);
        }
    }
}