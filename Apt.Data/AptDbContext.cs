using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Apt.Core.Domain.Appointments;

namespace Apt.Data
{
    public class AptDbContext : DbContext, IDbContext  
    {
        public AptDbContext(string nameOrConnectionString)  : base(nameOrConnectionString)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointee>().ToTable("Appointee");
        }

        #region IDbContext Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Core.BaseEntity
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
