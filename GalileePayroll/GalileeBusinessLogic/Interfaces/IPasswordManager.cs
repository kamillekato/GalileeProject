using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeBusinessLogic.Interfaces
{
    interface IPasswordManager
    {
        bool IsPasswordMatch(string password,string salt,string hash);
        string GeneratePasswordHash(string plainTextPassword, out string salt);
    }
}
