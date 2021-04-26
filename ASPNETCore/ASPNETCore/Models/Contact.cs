using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Linkedin { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]

        public Employee Employee { get; set; }
    }
}
