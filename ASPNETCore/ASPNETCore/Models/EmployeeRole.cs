using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_EmployeeRole")]
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }

        //public ICollection<Employee> Employees { get; set; }
        //public int Employee_Id { get; set; }
        //[ForeignKey("Id")]
        public Employee Employee { get; set; }
        //public int Role_Id { get; set; }
        //[ForeignKey("Id")]
        //public Role Role { get; set; }
    }
}
