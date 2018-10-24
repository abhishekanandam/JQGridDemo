using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JQGridDemo.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace JQGridDemo.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbSet<T> DbSet;
        DbContext dataContext;

        public GenericRepository()
        {
            dataContext = new NorthwindEntities();
            DbSet = dataContext.Set<T>();
        }

        public GenericRepository(DbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
        }

        //================================================================
        //================================================================

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.AddOrUpdate(entity);
            dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            dataContext.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        #endregion
    }
}
