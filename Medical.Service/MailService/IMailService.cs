using Medical.Model.DTOs.Requests.Mail;

namespace Medical.Service.MailService
{
    /// <summary>
    /// The mail service interface
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Sends the submit mail using the specified submit mail request
        /// </summary>
        /// <param name="submitMailRequest">The submit mail request</param>
        Task SendSubmitMailAsync(SubmitMailRequest submitMailRequest);
        Task SendcommunicationMailAsync(string uEmail, string EmailHeaderImage, string EmailSubject, /*string uName,*/ string applicationName, string EmailHtmlBody, string EmailRegards, string EmailFooterImage);
    }
}
