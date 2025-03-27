namespace Medical.Common.Extensions.LINQ
{
    /// <summary>
    /// The linq extensions class
    /// </summary>
    public static partial class LINQExtensions
    {
        /// <summary>
        /// Determines if each element from source 
        /// is contained in <paramref name="target"/> using default
        /// equality comparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsSubsetOf<T>(this IEnumerable<T> first, IEnumerable<T> target)
        {
            foreach (var item in first)
            {
                if (!target.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
