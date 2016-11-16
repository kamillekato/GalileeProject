using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GalileeDataAccess.Repository
{
    public class BaseRepository<T> where T : class
    {
        public virtual bool Add(T entity)
        {
            bool returnValue = false;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    context.Entry(entity).State = EntityState.Added;
                    returnValue = !(context.SaveChanges() <= 0);
                }
            }
            catch (Exception ex)
            {
                return returnValue;
            }
            return returnValue;
        }

        public virtual bool Delete(T entity)
        {
            bool returnValue = false;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    returnValue = !(context.SaveChanges() <= 0);
                }
            }
            catch (Exception ex)
            {
                return returnValue;
            }
            return returnValue;
        }

        public virtual bool Update(T entity)
        {
            bool returnValue = false;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    returnValue = !(context.SaveChanges() <= 0);
                }
            }
            catch (Exception ex)
            {
                return returnValue;
            }
            return returnValue;
        }

        public virtual List<T> GetAll()
        {
            List<T> returnList = null;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    returnList=context.Set<T>().ToList<T>();
                }
            }
            catch (Exception ex)
            {
                return returnList;
            }
            return returnList;
        }

        public virtual List<T> GetList(Expression<Func<T,bool>> condition)
        {
            List<T> returnList = null;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    returnList = context.Set<T>().Where(condition).ToList<T>();
                }
            }
            catch (Exception ex)
            {
                return returnList;
            }
            return returnList;
        }

        public virtual T Get(Expression<Func<T,bool>> condition)
        {
            T returnEntity = null;
            try
            {
                using (var context = new GALILEEEntities())
                {
                    returnEntity = context.Set<T>().Where(condition).SingleOrDefault<T>();
                }
            }
            catch (Exception ex)
            {
                return returnEntity;
            }
            return returnEntity;
        }

    }
}
