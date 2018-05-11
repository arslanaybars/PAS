using Newtonsoft.Json;
using Plugin.Common;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Plugin.Sample.EmailSender
{
    public class EmailPlugin : IPlugin
    {
        public string Name => "EmailPlugin";

        public PluginResponse Execute(string request)
        {
            EmailSenderRequestModel req = JsonConvert.DeserializeObject<EmailSenderRequestModel>(request);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(req.MailServer);

                mail.From = new MailAddress(req.FromAddress);
                mail.To.Add(req.ToAddress);
                if (req.BCCAddress != null)
                {
                    mail.Bcc.Add(req.BCCAddress);
                }
                mail.Subject = req.Subject;
                mail.Body = req.Body;
                mail.IsBodyHtml = req.IsHtml;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(req.Username, req.Password);
                SmtpServer.EnableSsl = true;

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return new PluginResponse(false, "Unsuccess", "Error while plugin executing"); 
            }

            return new PluginResponse(true, "Success", "Plugin executed successfully"); 
        }

        public Task<PluginResponse> ExecuteAsync(string request)
        {
            throw new NotImplementedException();
        }
    }
}
