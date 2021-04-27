using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    //Punya Muljadi
    public interface IMajor : IGeneralRepository<Major>
    {
        IEnumerable<Education> GetEducationsByDegree(string Degree);
        IEnumerable<Education> GetEducationsByMajor(string Major);
        IEnumerable<Education> GetEducationsByUniversity(string University);
    }
}
