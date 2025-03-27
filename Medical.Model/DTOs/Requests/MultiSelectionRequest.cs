namespace Medical.Model.DTOs.Requests
{
    /// <summary>
    /// The multi selection request class
    /// </summary>
    public class MultiSelectionRequest
    {
        /// <summary>
        /// Gets or sets the value of the application ids
        /// </summary>
        public List<int> ApplicationIds { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSelectionRequest"/> class
        /// </summary>
        public MultiSelectionRequest()
        {
            ApplicationIds = new List<int>();
        }
    }
}