using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeBusinessLogic.Interfaces
{
    public interface IUserManager
    {
        bool AddUser(USER user);
        bool LoginUser(string userName, string password);
        bool IsUserNameExist(string userName);
        bool DeleteUser(string username);
        bool UpdateUser(USER user);
        USER GetUserByUsername(string userName);
        USER GetUser(int id);
    }
}
