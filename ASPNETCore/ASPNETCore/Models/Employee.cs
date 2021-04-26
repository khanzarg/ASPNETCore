using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{

    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public int Address_Id { get; set; }
        [ForeignKey("Address_Id")]
        public Address Address { get; set; }

        public int Education_Id { get; set; }
        [ForeignKey("Education_Id")]
        public Education Education { get; set; }

        public int Contact_Id { get; set; }
        [ForeignKey("Contact_Id")]
        public Contact Contact { get; set;}

        public ICollection<EmployeeRole> EmployeeRoles { get; set; }

        //public int role { get; set; }
        //[ForeignKey("role")]
        //public EmployeeRole EmployeeRole
    }
}
