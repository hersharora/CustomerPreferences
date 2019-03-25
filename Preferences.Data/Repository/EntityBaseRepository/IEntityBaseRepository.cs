using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Preferences.Models;

namespace Preferences.Data.Repository
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}
