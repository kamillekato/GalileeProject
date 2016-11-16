using GalileeBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalileeDatabase;
using GalileeDataAccess.Interface;
using GalileeDataAccess.Repository;

namespace GalileeBusinessLogic.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        IEmployeeRepository EmpRepo;
        public EmployeeManager()
        {
            EmpRepo = new EmployeeRepository();
        }


        public bool AddEmployee(EMPLOYEE employee)
        {
            return EmpRepo.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return EmpRepo.Delete(GetEmployeeByID(id));
        }

        public bool UpdateEmployee(EMPLOYEE employee)
        {
            return EmpRepo.Update(employee);
        }

        public bool UpdateEmployeeDesignation(int id,string designation)
        {
            return EmpRepo.UpdateDesignation(id, designation);
        }

        public EMPLOYEE GetEmployeeByID(int id)
        {
            return EmpRepo.Get(emp => emp.ID == id);
        }

        public List<EMPLOYEE> GetEmployeeList()
        {
            return EmpRepo.GetAll();
        }
    }
}
