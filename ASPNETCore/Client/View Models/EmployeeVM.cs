using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.View_Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
