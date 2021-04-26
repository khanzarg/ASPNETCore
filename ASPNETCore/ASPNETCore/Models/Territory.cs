using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_Territory")]
    public class Territory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string SubDistrict { get; set; }
        [ForeignKey("SubDistrict")] //[ForeignKey("Id")]
        //public SubDistrict subDistrict { get;set }
        //public ICollection<Address> addresses { get; set; }

    }
}
