namespace Medical.Model.Entities
{
    /// <summary>
    /// The interface class
    /// </summary>
    public class Interface
    {
        /// <summary>
        /// Gets or sets the value of the interface id
        /// </summary>
        public int InterfaceId { get; set; }
        /// <summary>
        /// Gets or sets the value of the txture id
        /// </summary>
        public string TxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the value of the max response
        /// </summary>
        public int MaxResponse { get; set; }
        /// <summary>
        /// Gets or sets the value of the traffic inbound
        /// </summary>
        public int TrafficInbound { get; set; }
        /// <summary>
        /// Gets or sets the value of the traffic outbound
        /// </summary>
        public int TrafficOutbound { get; set; }
        /// <summary>
        /// Gets or sets the value of the is encrypted
        /// </summary>
        public bool IsEncrypted { get; set; }
        /// <summary>
        /// Gets or sets the value of the personal data
        /// </summary>
        public bool PersonalData { get; set; }
        /// <summary>
        /// Gets or sets the value of the endpoint id
        /// </summary>
        public int EndpointId { get; set; }
        /// <summary>
        /// Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the value of the port range
        /// </summary>
        public int PortRange { get; set; }
        /// <summary>
        /// Gets or sets the value of the protocol type id
        /// </summary>
        public int ProtocolTypeId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interface"/> class
        /// </summary>
        public Interface()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}