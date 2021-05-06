using ASPNETCore.Context;
using ASPNETCore.Models;
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

        public void SendForgetPassword(string url, string token, Employee employee)
        {
            var parameter = context.Parameters.Find(1);
            var user = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(parameter.Name, parameter.Value),
            };

            user.Send(parameter.Name, employee.Email, "Reset Password Request", $"Link Reset Password : {url}{token}");
        }
    }
}
