namespace Medical.Model.DTOs.Requests
{
    /// <summary>
    /// The paginated request class
    /// </summary>
    public class PaginatedRequest
    {
        /// <summary>
        /// Gets or sets the value of the page index
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// Gets or sets the value of the page size
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Describes whether this instance is valid
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsValid()
        {
            return PageIndex is not null 
                && PageSize is not null
                && PageIndex > 0
                && PageSize > 0;
        }
    }
}
