using Medical.Common.Constants;
using Medical.Data.EF;
using Medical.Data.EF.Domain;
using Medical.Model.DTOs.Requests.Mail;
using Medical.Model.Options.Mail;
using Medical.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Medical.Service.MailService
{
    /// <summary>
    /// The mail service class
    /// </summary>
    /// <seealso cref="IMailService"/>
    public class MailService : IMailService
    {

        /// <summary>
        /// The mail settings
        /// </summary>
        private readonly MailSettings _mailSettings;
        private readonly MedicalDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailService"/> class
        /// </summary>
        /// <param name="mailSettings">The mail settings</param>
        public MailService(IOptions<MailSettings> mailSettings, MedicalDbContext dbContext, IUserRepository userRepository)
        {
            _mailSettings = mailSettings.Value;
            _dbContext = dbContext;
            _userRepository = userRepository;
        }
        /// <summary>
        /// Sends the submit mail using the specified submit mail request
        /// </summary>
        /// <param name="submitMailRequest">The submit mail request</param>
        public async Task SendSubmitMailAsync(SubmitMailRequest submitMailRequest)
        {
            MailAddress from = new MailAddress(_mailSettings.Mail);
            MailAddress to = new MailAddress(submitMailRequest.Email);

            MailMessage message = new MailMessage(from, to);
            message.Body = _mailSettings.Salutation
                + "\n\n"
                + DecryptString(submitMailRequest.Message)
                + "\n\n"
                + submitMailRequest.FirstName
                + "\nMember Firm: "
                + submitMailRequest.MemberFirm
                + "\nPhone: "
                + submitMailRequest.Phone
                + "\n\n"
                + _mailSettings.FooterMessage;

            message.Subject = _mailSettings.Subject == string.Empty ?
                "Submit Messege from " + submitMailRequest.FirstName : _mailSettings.Subject;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = _mailSettings.Host;
            smtp.Port = _mailSettings.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            if (_mailSettings.IsEnabled)
            {
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task SendcommunicationMailAsync(string uEmail, string EmailHeaderImage, string EmailSubject, /*string uName,*/ string applicationName, string EmailHtmlBody, string EmailRegards, string EmailFooterImage)
        {
            try
            {

                // Add multiple and single To email 
                //List<MailAddress> addresses = new List<MailAddress>();
                string[] emailGrp = uEmail.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string Multiemail in emailGrp)
                {
                    var userName = _userRepository.GetUserByEmailAsync(Multiemail);
                    var uName = userName.Result.UserName;
                    var uActive = userName.Result.IsApprove;

                    if (uActive)
                    {
                        MailMessage message = new MailMessage();

                        // From Email
                        message.From = new MailAddress(_mailSettings.Mail);

                        message.To.Add(new MailAddress(Multiemail));

                        string dateTime = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy");
                        // Header image
                        string headerImageUrl = DecryptString(Convert.ToString(EmailHeaderImage));

                        // Footer image
                        string footerImageUrl = DecryptString(Convert.ToString(EmailFooterImage));

                        // Html Body
                        string htmlBody = string.Format(DecryptString(Convert.ToString(EmailHtmlBody)), "");

                        htmlBody = htmlBody.Replace("@uNamee", uName);
                        htmlBody = htmlBody.Replace("@dateTimee", dateTime);
                        htmlBody = htmlBody.Replace("@Regardse", EmailRegards);
                        htmlBody = htmlBody.Replace("@appName", applicationName);

                        string Body = "<html>";
                        Body = Body + "<body height: 100%>";
                        Body = Body + "<header><img src = '" + headerImageUrl + "' width = '1000px'></header>";
                        Body = Body + htmlBody;
                        Body = Body + "<footer><img src = '" + footerImageUrl + "' width = '1000px'></footer>";
                        Body = Body + "</body>";
                        Body = Body + "</html>";

                        AlternateView avHtml = AlternateView.CreateAlternateViewFromString(Body, Encoding.Default, MediaTypeNames.Text.Html);

                        message.AlternateViews.Add(avHtml);
                        message.IsBodyHtml = true;

                        // Email Subject
                        message.Subject = string.IsNullOrEmpty(EmailSubject) ? "Submit Messege from " + uEmail : EmailSubject;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = _mailSettings.Host;
                        smtp.Port = _mailSettings.Port;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                        if (_mailSettings.IsEnabled)
                        {
                            try
                            {
                                smtp.Send(message);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
        private string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}
