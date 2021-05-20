using ASPNETCore.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASPNETCore.Services
{
    public class EmailManager
    {
        private IConfiguration _config;
        private readonly MyContext _context;
        private static string Host, Port;

        public EmailManager(IConfiguration config, MyContext context) 
        {
            _config = config.GetSection("MailSettings");
            //Mail = _config.GetSection("Mail").Value;
            //DisplayName = _config.GetSection("DisplayName").Value;
            //Password = _config.GetSection("Password").Value;
            Host = _config.GetSection("Host").Value;
            Port = _config.GetSection("Port").Value;

            _context = context;
        }

        

        public void SendEmail(string From, string Subject, string Body, string To)
        {
            var parameter = _context.Parameters.Find(1);

            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt32(Port);
            smtp.Credentials = new NetworkCredential(parameter.Name, parameter.Value);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
