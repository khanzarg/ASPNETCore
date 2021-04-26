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

        //public int ProvinceId { get; set; }

        //[ForeignKey ("ProvinceId")]

        public Province Province { get; set; }

        
    }
}

