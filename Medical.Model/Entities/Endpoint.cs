namespace Medical.Model.Entities
{
    /// <summary>
    /// The endpoint class
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// Gets or sets the value of the endpoint id
        /// </summary>
        public int EndpointId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Endpoint"/> class
        /// </summary>
        public Endpoint()
        {
            Name = string.Empty;
        }
    }
}