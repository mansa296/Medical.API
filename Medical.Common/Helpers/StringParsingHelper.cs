namespace Medical.Common.Helpers
{
    /// <summary>
    /// The string parsing helper class
    /// </summary>
    public static class StringParsingHelper
    {
        /// <summary>
        /// Gets the comma separated string values using the specified values
        /// </summary>
        /// <param name="values">The values</param>
        /// <returns>The list</returns>
        public static List<string> GetCommaSeparatedStringValues(this string values)
        {
            var list = new List<string>();

            if (string.IsNullOrEmpty(values))
            {
                return list;
            }

            if (values.Contains('\u002C'))
            {
                var commaSeparatedValues = values.Split('\u002C');
                list.AddRange(commaSeparatedValues);
            }
            else
            {
                list.Add(values);
            }

            return list;
        }
    }
}