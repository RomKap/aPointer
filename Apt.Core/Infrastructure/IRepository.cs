using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Apt.Core.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(T item);     
        void Update(T item);
        T FindByID(Guid id);
        T FindByID(T item);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
    }
}
