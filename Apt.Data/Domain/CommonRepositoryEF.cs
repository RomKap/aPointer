using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Domain.Appointments;
using System.Data.Entity;
using Apt.Core;
using Apt.Data.Common;


namespace Apt.Data.Domain
{
    public sealed class CommonRepositoryEF<T> : RepositoryEF<T>, ICommonRepository<T> where T : BaseEntity
    {
        public CommonRepositoryEF(IDbContext context) : base(context)
        {
        }

        public void AddDirect(Appointee aptee)
        {
            //not implemented
        }

        #region IAppointeeRepository<T> Members

        public void AddDirect(T item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
