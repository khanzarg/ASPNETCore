using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_Major")]
    public class Major
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }
        public ICollection<Education> Educations { get; set; }
        //Revisi dari Muljadi
    }
}
