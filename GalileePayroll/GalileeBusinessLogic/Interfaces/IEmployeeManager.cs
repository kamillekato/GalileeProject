using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeBusinessLogic.Interfaces
{
    public interface IEmployeeManager
    {
        bool AddEmployee(EMPLOYEE employee);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EMPLOYEE employee);
        bool UpdateEmployeeDesignation(int id, string designation);
        List<EMPLOYEE> GetEmployeeList();
        EMPLOYEE GetEmployeeByID(int id);
    }
}
