using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers.Models
{
    [Table("TB_M_Address")]
    public class Address
    {   
        [Key]
        public int Id { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        [ForeignKey("Territory")]
        public int Territory_id { get; set; }
        public Territory Territory { get; set; }
      
    }
}
