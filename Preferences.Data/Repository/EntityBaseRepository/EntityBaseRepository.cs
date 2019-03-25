using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Preferences.Data.Context;
using Preferences.Data.Pattern;
using Preferences.Models;

namespace Preferences.Data.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private PreferenceContext Context;

        protected IDbFactory DbFactory { get; private set; }

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        protected PreferenceContext DbContext
        {
            get { return Context ?? (Context = DbFactory.Init()); }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual T GetSingle(int id)
        {
            return DbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entityInDB = DbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            //if (entityInDB != null)
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entityInDB);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entityInDB = DbContext.Set<T>().FirstOrDefault(predicate);
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entityInDB);
            dbEntityEntry.State = EntityState.Deleted;
        }

    }
}
