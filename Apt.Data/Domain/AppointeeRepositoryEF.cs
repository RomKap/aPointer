using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Domain.Appointments;
using System.Data.Entity;

namespace Apt.Data.Domain
{
    public sealed class AppointeeRepositoryEF : RepositoryEF<Appointee>, IAppointeeRepository<Appointee>
    {
        public AppointeeRepositoryEF(IDbContext context) : base(context)
        {
        }

        public void AddDirect(Appointee aptee)
        {
            //not implemented
        }
    }
}
