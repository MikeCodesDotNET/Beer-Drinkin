using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;

namespace BeerDrinkin.Service.Models.EmailService
{
    public class EmailClient
    {
        private readonly SmtpClient _client;
        public EmailClient(string host, int port, string username, string password)
        {
            _client = new SmtpClient
            {
                Host =host,
                Port =port,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            _client.UseDefaultCredentials = false;
            _client.EnableSsl = true;
            _client.Credentials = new NetworkCredential(username,password);
        }
        public bool SendMessage(string from, string to,
             string subject, string body)
        {
            MailMessage mailMessage = null;
            bool isSent = false;
            try
            {
                mailMessage = new MailMessage(from, to, subject, body);
                mailMessage.DeliveryNotificationOptions = 
                       DeliveryNotificationOptions.OnFailure;
                // Send it
                
                _client.Send(mailMessage);
                isSent = true;
            }
            // Catch any errors, these should be logged 
            catch (Exception ex)
            {
                
            }
            finally
            {
                mailMessage.Dispose();
            }
            return isSent;
        }
        
    }
}