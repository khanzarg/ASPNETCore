using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_T_SubDistrict")]
    public class SubDistrict
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public int District_Id { get; set; }
        public District District { get; set; }
        public ICollection<Territory> Territory { get; set; }


    }
}
