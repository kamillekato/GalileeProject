using GalileeDataAccess.Interface;
using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Repository
{
    public class UserRepository : BaseRepository<USER>,IUserRepository
    {
        IErrorRepository errorRepo;

        public UserRepository()
        {
            errorRepo = new ErrorRepository();
        }


        public USER GetUserByUserName(string userName)
        {
            USER user = null;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    user = context.USERs.Where(usr => usr.UserName == userName).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                errorRepo.Add(new ERRORLOG() { Message = ex.Message.ToString(), Date = DateTime.Now });
                return user;
            }
            return user; 
        }

        public bool IsUserNameExist(string userName)
        { 
            try
            {
                using (var context = new GALILEEEntities())
                {
                    return context.USERs.Any(usr => usr.UserName == userName);
                }
            }
            catch (Exception ex)
            {
                errorRepo.Add(new ERRORLOG() { Message = ex.Message.ToString(), Date = DateTime.Now });
                return false;
            } 
        }
    }
}
