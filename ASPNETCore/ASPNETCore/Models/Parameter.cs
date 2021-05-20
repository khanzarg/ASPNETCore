using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Models
{
    [Table("TB_M_Parameter")]
    public class Parameter
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
