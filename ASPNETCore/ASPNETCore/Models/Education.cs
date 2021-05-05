using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_Education")]
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }

        public Major Major { get; set; }

        public University University { get; set; }
        public Employee Employee { get; set; }
    }
}
