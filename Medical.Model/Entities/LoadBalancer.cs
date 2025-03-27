namespace Medical.Model.Entities
{
    /// <summary>
    /// The load balancer class
    /// </summary>
    public class LoadBalancer
    {
        /// <summary>
        /// Gets or sets the value of the load balancer id
        /// </summary>
        public int LoadBalancerId { get; set; }
        /// <summary>
        /// Gets or sets the value of the txture id
        /// </summary>
        public string TxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the is stateless
        /// </summary>
        public bool IsStateless { get; set; }
        /// <summary>
        /// Gets or sets the value of the can be virtualized
        /// </summary>
        public bool CanBeVirtualized { get; set; }
        /// <summary>
        /// Gets or sets the value of the technology
        /// </summary>
        public string Technology { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancer"/> class
        /// </summary>
        public LoadBalancer()
        {
            Name = string.Empty;
            Technology = string.Empty;
        }
    }
}