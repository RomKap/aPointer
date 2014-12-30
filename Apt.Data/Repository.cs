using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core;
using Apt.Core.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using RepoWrapper;
using System.Linq.Expressions;
 

namespace Apt.Data
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
       private readonly string _tableName;

       protected IDbConnection Connection
       {
           get
           {
               return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
           }
       }

       public Repository(string tableName)
       {
           _tableName = tableName;
       }

       internal virtual dynamic Mapping(T item)
       {
           return item;
       }

       public virtual void Add(T item)
       {
           using (IDbConnection cn = Connection)
           {
               var parameters = (object)Mapping(item);
               cn.Open();
               //item.ID = cn.Insert<Guid>(_tableName, parameters);
                cn.Insert<int>(_tableName, parameters);
           }
       }

       public virtual void Update(T item)
       {
           using (IDbConnection cn = Connection)
           {
               var parameters = (object)Mapping(item);
               cn.Open();
               cn.Update(_tableName, parameters);
           }
       }

       public virtual void Remove(T item)
       {
           using (IDbConnection cn = Connection)
           {
               var parameters = (object)Mapping(item);
               cn.Open();
               //cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = item.ID });
               cn.Delete<int>(_tableName, parameters);
           }
       }       

       public virtual T FindByID(Guid id)
       {
           T item = default(T);

           using (IDbConnection cn = Connection)
           {
               cn.Open();
               item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
           }

           return item;
       }

       public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
       {
           IEnumerable<T> items = null;

           // extract the dynamic sql query and parameters from predicate
           QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);

           using (IDbConnection cn = Connection)
           {
               cn.Open();
               items = cn.Query<T>(result.Sql, (object)result.Param);
           }

           return items;
       }

       public virtual IEnumerable<T> FindAll()
       {
           IEnumerable<T> items = null;

           using (IDbConnection cn = Connection)
           {
               cn.Open();
               items = cn.Query<T>("SELECT * FROM " + _tableName);
           }

           return items;
       }
    }
}
