using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Interface
{
    public interface IUserRepository : IRepository<USER>
    {
        USER GetUserByUserName(string userName);
        bool IsUserNameExist(string userName);
    }
}
