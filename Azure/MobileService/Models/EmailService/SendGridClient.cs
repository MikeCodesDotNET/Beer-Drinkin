using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;
using SendGrid;
using System.Threading.Tasks;

namespace BeerDrinkin.Service.Models.EmailService
{
    public class SendGridClient
    {
        readonly string apiKey;

        public SendGridClient(string apiKey)
        {
            this.apiKey = apiKey;
        }
        public async Task<bool> SendMessage(string from, string to, string subject, string body)
        {
            try
            {
                // Create the email object first, then add the properties.
                var message = new SendGridMessage {From = new MailAddress(@from)};

                // Add the message properties.
                message.AddTo(to);
                message.Subject = subject;
                message.Text = body;

                var transportWeb = new Web(apiKey);

                // Send the email.
                await transportWeb.DeliverAsync(message);
            }
            catch
            {
                //TODO log the error
                return false;
            }
            return true;
        }
        
    }
}