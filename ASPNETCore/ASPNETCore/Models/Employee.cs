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

        public Address Address { get; set; }
      
        public Education Education { get; set; }

        public Contact Contact { get; set;}

        public Account Account { get; set; }

        public ICollection<EmployeeRole> EmployeeRoles { get; set; }

    }
}
