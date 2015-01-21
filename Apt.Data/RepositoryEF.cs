using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Infrastructure;
using Apt.Core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Reflection;

namespace Apt.Data
{
    public abstract class RepositoryEF<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public RepositoryEF(IDbContext context)
        {     
            this._context = context;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        #region IRepository<T> Members

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException("entity");           

            this.Entities.Add(item);

            this._context.SaveChanges();    
        }

        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException("entity");

            T eItem = FindByID(item);

            this.Entities.Remove(eItem);

            this._context.SaveChanges();
        }

        public void Update(T item)
        {
            if (item == null)
                throw new ArgumentNullException("entity"); 

            this._context.SaveChanges();
        }

        public T FindByID(Guid id)
        {
            return this.Entities.Find(id);
        }

        public T FindByID(T item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            string primaryKeyCoulmn = props.Where(s => s.GetCustomAttributes(typeof(PrimaryKey), true).Length > 0).Select(p => p.Name).FirstOrDefault();

            int ID = Convert.ToInt32(item.GetType().GetProperty(primaryKeyCoulmn).GetValue(item, null));

             return this.Entities.Find(ID);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            return this.Entities;
        }

        #endregion
    }
}
