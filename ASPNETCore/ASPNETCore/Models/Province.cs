using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_Province")]
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
