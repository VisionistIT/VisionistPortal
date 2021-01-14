using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VisionistPortal
{
    public class EmailHelper
    {
        public const string SenderEmailAddress = "admin@visionistsolutions.net";
        public const string SenderPassword = "Av@VS2021";
        public const string SenderHost = "smtp.gmail.com";
        public const int SenderPort = 587;
        public const string RecipientEmailAddress = "admin@visionistsolutions.net";
        internal static Task Send(string name, string email, string phone, string message)
        {
            phone = string.IsNullOrEmpty(phone) ? "--" : phone;
            var subject = $"Visionistsolutions.com-ContactUs";
            var body = $"Name: {name}{Environment.NewLine}Email: {email}{Environment.NewLine}Phone: {phone}{Environment.NewLine}{Environment.NewLine}{message}";
            return SendEmail(RecipientEmailAddress, subject, body);
        }
        internal static Task SendEmail(string recipients, string subject, string body)
        {
            SmtpClient client = new SmtpClient()
            {
                Port = SenderPort,
                Host =SenderHost,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderPassword)
            };

            MailMessage mm = new MailMessage(SenderEmailAddress
                
                , recipients, subject, body)
            {
                IsBodyHtml = body.StartsWith("<html>"),
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            return Task.Factory.StartNew(() =>
            {
                try { client.Send(mm); }
                catch (System.Exception ex)
                {
                    string m = ex.Message;
                }
            });
        }

    }
}
