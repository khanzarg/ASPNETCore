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

        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
