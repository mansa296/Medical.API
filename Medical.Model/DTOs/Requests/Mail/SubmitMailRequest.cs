using System.ComponentModel.DataAnnotations;

namespace Medical.Model.DTOs.Requests.Mail
{
    /// <summary>
    /// The submit mail request class
    /// </summary>
    public class SubmitMailRequest
    {
        /// <summary>
        /// Gets or sets the value of the first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the value of the last name
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the member firm
        /// </summary>
        [Required]
        public string MemberFirm { get; set; }
        /// <summary>
        /// Gets or sets the value of the messege
        /// </summary>
        [Required]
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the value of the phone
        /// </summary>
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Salutation { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitMailRequest"/> class
        /// </summary>
        public SubmitMailRequest()
        {
            Message = string.Empty;
            Phone = string.Empty;
            Subject = string.Empty;
            Salutation = string.Empty;
        }
    }
    
}
