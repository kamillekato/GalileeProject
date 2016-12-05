using GalileeBusinessLogic.Interfaces;
using GalileeDataAccess.Interface;
using GalileeDataAccess.Repository;
using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeBusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        IUserRepository userRepo;
        IPasswordManager pwdManager;
        public UserManager()
        {
            userRepo = new UserRepository();
            pwdManager = new PasswordManager();
        }

        public bool AddUser(USER user)
        {
            string salt = string.Empty; 
            user.Password = pwdManager.GeneratePasswordHash(user.Password, out salt);
            user.Salt = salt;
            return userRepo.Add(user);
        }
        
        public bool LoginUser(string userName , string password)
        {
            USER user = userRepo.GetUserByUserName(userName);
            if (user != null) 
            {
                return pwdManager.IsPasswordMatch(password,user.Salt,user.Password);
            }
            return false;
        }

        public bool IsUserNameExist(string userName)
        {
            return userRepo.IsUserNameExist(userName);
        }

        public bool DeleteUser(string username)
        {
            USER user = GetUserByUsername(username);
            return userRepo.Delete(user);
        }

        public bool UpdateUser(USER user)
        {
            return userRepo.Update(user);
        }

        public USER GetUser(int id)
        {
            return userRepo.Get(user => user.ID == id);
        }




        public USER GetUserByUsername(string userName)
        {
            return userRepo.GetUserByUserName(userName);
        }
        public List<USER> GetAllListOfUserByType(string type)
        {
            return userRepo.GetList(user => user.Type == type);
        }

    }
}
