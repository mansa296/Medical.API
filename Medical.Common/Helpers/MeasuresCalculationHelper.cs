namespace Medical.Common.Helpers
{
    /// <summary>
    /// The measures calculation helper class
    /// </summary>
    public class MeasuresCalculationHelper
    {
        /// <summary>
        /// Calculates the median using the specified numbers
        /// </summary>
        /// <param name="numbers">The numbers</param>
        /// <returns>The long</returns>
        public static long CalculateMedian(List<long> numbers)
        {
            if (numbers.Count == 0)
                return 0;

            numbers = numbers.OrderBy(n => n).ToList();

            var halfIndex = numbers.Count / 2;

            if (numbers.Count % 2 == 0)
            {
                return (numbers[halfIndex] + numbers[halfIndex - 1]) / 2;
            }

            return numbers[halfIndex];
        }
    }
}