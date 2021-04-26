using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Province Province { get; set; }
        public ICollection<SubDistrict>  SubDistrict { get; set; }


        
    }
}

