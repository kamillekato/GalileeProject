using GalileeDataAccess.Interface;
using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<EMPLOYEE>, IEmployeeRepository
    {
        IErrorRepository errorRepo;

        public EmployeeRepository()
        {
            errorRepo = new ErrorRepository();
        }

        public bool UpdateDesignation(int id,string designation)
        {
            bool returnValue = false;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    var employee = context.EMPLOYEEs.Where(emp => emp.ID == id).SingleOrDefault();
                    employee.Designation = designation;
                    Update(employee);

                }
            }
            catch (Exception ex)
            {
                errorRepo.Add(new ERRORLOG() { Message = ex.Message.ToString(), Date = DateTime.Now });
                return returnValue;
            }
            return returnValue;
        }
    }
}
