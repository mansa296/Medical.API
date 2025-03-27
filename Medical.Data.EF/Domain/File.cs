using System.ComponentModel.DataAnnotations;

namespace Medical.Data.EF.Domain
{
    /// <summary>
    /// The file class
    /// </summary>
    /// <seealso cref="IEntity"/>
    public class File : IEntity
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of creation date time
        /// </summary>
        public DateTime CreationDateTime { get; set; }
        /// <summary>
        /// Gets or sets the value of the asset id
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Gets or sets the value of the file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the value of the content type
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the value of the data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Gets or sets the value of the file type
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class
        /// </summary>
        public File()
        {
            CreationDateTime = DateTime.Now;
            FileName = string.Empty;
            ContentType = string.Empty;
            Data = string.Empty;
            FileType = string.Empty;
        }
    }
}