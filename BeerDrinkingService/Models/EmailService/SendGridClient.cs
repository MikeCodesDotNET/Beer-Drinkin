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
        string _apiKey;

        public SendGridClient(string apiKey)
        {
            _apiKey = apiKey;
        }
        public async Task<bool> SendMessage(string from, string to, string subject, string body)
        {
            try
            {
                // Create the email object first, then add the properties.
                var message = new SendGridMessage();

                // Add the message properties.
                message.From = new MailAddress(from);

                message.AddTo(to);

                message.Subject = subject;

                message.Text = body;

                var transportWeb = new Web(_apiKey);

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