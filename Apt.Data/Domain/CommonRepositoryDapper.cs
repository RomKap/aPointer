using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Domain.Appointments;
using System.Data;
using Dapper;
using System.Reflection;

namespace Apt.Data.Domain
{
    public sealed class AppointeeRepository : RepositoryDapper<Appointee>, ICommonRepository<Appointee>
    {
        public AppointeeRepository() : base("Appointee"){}

        public void AddDirect(Appointee aptee)
        {
            using (IDbConnection cn = Connection)
            {   
                cn.Open();
                string query = "insert into Appointee (FirstName, LastName) values (@FirstName, @LastName) ";
                cn.Query<Appointee>(query, new { FirstName = aptee.FirstName, LastName = aptee.LastName });
            }
        }
    }

    public sealed class AppointerRepository : RepositoryDapper<Appointer>, ICommonRepository<Appointer>
    {
        public AppointerRepository() : base("Appointer") { }

        #region ICommonRepository<Appointer> Members

        public void AddDirect(Appointer aptr)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                string query = "insert into Appointer (FirstName, LastName) values (@FirstName, @LastName) ";
                cn.Query<Appointee>(query, new { FirstName = aptr.FirstName, LastName = aptr.LastName, ModifiedOn = DateTime.Now });
            }
        }

        #endregion
    }
}
