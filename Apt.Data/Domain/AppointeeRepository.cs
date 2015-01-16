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
    public sealed class AppointeeRepository : Repository<Appointee>
    {
        public AppointeeRepository() : base("Appointee"){}

        public void AddOther(dynamic ditem)
        {
            using (IDbConnection cn = Connection)
            {   
                string name = ditem.name;
             
                cn.Open();
                string query = "insert into Appointer (FirstName, LastName) values (@FirstName, @LastName) ";
                cn.Query<dynamic>(query, new { FirstName = ditem.FirstName, LastName = ditem.LastName });
            }
        }
    }

    public sealed class AppointerRepository : Repository<Appointer>
    {
        public AppointerRepository() : base("Appointer") { }
    }
}
