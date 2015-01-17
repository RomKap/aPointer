using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Infrastructure;
using Apt.Core.Domain.Appointments;
using Apt.Core;

namespace Apt.Data.Domain
{
    public interface IAppointeeRepository<T> : IRepository<T> where T : BaseEntity 
    {
        void AddDirect(T item);
    }
}
