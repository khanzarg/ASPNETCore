using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        //public string Username { get; set; }
        public string Password { get; set; }
        //public string EmailAddress { get; set; }
        //public Role Role { get; set; }
        public Employee Employee { get; set; }
    }
}
