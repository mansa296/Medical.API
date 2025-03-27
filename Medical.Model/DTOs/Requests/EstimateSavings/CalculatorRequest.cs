namespace Medical.Model.DTOs.Requests.EstimateSavings
{
    /// <summary>
    /// The calculator request class
    /// </summary>
    public class CalculatorRequest
    {
        /// <summary>
        /// Gets or inits the value of the number of server
        /// </summary>
        public decimal NumberOfServer { get; init; } = 100;
        /// <summary>
        /// Gets or sets the value of the percentage of virtualization
        /// </summary>
        public decimal PercentageOfVirtualization { get; set; } = 800;
        /// <summary>
        /// Gets or sets the value of the number of data room
        /// </summary>
        public decimal NumberOfDataRoom { get; set; } = 30;
        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        public decimal Volume { get; set; } = 500;
        /// <summary>
        /// Gets or sets the value of the number of security device
        /// </summary>
        public decimal NumberOfSecurityDevice { get; set; } = 10;
        /// <summary>
        /// Gets or sets the value of the number of support
        /// </summary>
        public decimal NumberOfSupport { get; set; } = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorRequest"/> class
        /// </summary>
        public CalculatorRequest()
        {
            NumberOfServer = 100;
        }
    }
}
