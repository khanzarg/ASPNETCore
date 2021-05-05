using ASPNETCore.Context;
using ASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASPNETCore.Handlers
{
    public class SendEmail
    {
        private readonly MyContext context;
        public SendEmail(MyContext context)
        {
            this.context = context;
        }
        
        public void SendForgotPassword(string token, string resetCode, string email) 
        {
            //[FromBody]Parameter parameter
            var parameter = context.Parameters.Find(1);
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(parameter.Name, parameter.Value);

            MailMessage m = new MailMessage();
            m.From = new MailAddress(parameter.Name);
            m.To.Add(new MailAddress(email));
            m.Subject = "Reset Password " + time24;
            m.IsBodyHtml = false;
            m.Body = "Hi " + "\nThis is your reset code for your account. "
                + resetCode + "\nReset link: https://localhost:44320/api/account/resetpassword \nToken: " + token + "\n Thank You";
            smtp.Send(m);
        }
    }
}
