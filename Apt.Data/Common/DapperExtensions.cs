using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RepoWrapper;


namespace Dapper
{
    public static class DapperExtensions
    {
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.First();
        }

        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }

        public static void Delete<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetDeleteQuery(tableName, param), param);            
        }

        public static T FindByID<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.FindByIDQuery(tableName, param), param);
            if (result.Count() > 0)
                return result.First();
            else
                return default(T);

            //return ReferenceEquals(result, null) ? default(T) : result.First();
        }
    }
}
