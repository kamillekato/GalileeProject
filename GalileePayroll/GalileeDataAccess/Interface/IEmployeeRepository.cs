using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Interface
{
    public interface IEmployeeRepository : IRepository<EMPLOYEE>
    {
        bool UpdateDesignation(int id,string designation);
    }
}
