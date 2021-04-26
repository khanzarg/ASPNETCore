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
        [Key]
        public int id { get; set; }
        public string Degree { get; set; }
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public Major Major { get; set; }
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public University University { get; set; }
    }
}
