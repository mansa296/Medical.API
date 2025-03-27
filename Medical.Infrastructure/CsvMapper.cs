using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Medical.Infrastructure
{
    /// <summary>
    /// The csv mapper class
    /// </summary>
    public class CsvMapper
    {
        /// <summary>
        /// Describes whether try parse records
        /// </summary>
        /// <typeparam name="TModel">The model</typeparam>
        /// <param name="csvString">The csv string</param>
        /// <param name="result">The result</param>
        /// <param name="config">The config</param>
        /// <returns>The bool</returns>
        public static bool TryParseRecords<TModel>(string csvString, out List<TModel> result, CsvConfiguration? config = null)
        {
            try
            {
                result = ParseRecords<TModel>(csvString, config);
                return true;
            }
            catch(Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Parses the records using the specified csv string
        /// </summary>
        /// <typeparam name="TModel">The model</typeparam>
        /// <param name="csvString">The csv string</param>
        /// <param name="config">The config</param>
        /// <returns>A list of t model</returns>
        public static List<TModel> ParseRecords<TModel>(string csvString, CsvConfiguration? config = null)
        {
            config ??= new(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower().Replace(" ", ""),
                HeaderValidated = null,
                MissingFieldFound = null,
                DetectDelimiter = true
            };

            var bytes = Encoding.ASCII.GetBytes(csvString);
            using MemoryStream ms = new(bytes);
            using var reader = new StreamReader(ms);
            using CsvReader csv = new(reader, config);
            return csv.GetRecords<TModel>().ToList();
        }


    }
}
