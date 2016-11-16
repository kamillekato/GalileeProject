using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        List<T> GetAll();
        List<T> GetList(Expression<Func<T,bool>> condition);
        T Get(Expression<Func<T,bool>> condition);

    }
}
