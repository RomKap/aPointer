using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Apt.Core.Infrastructure;

using Apt.Core.Domain.Appointments;
using Apt.Data.Domain;

namespace Apt.Services
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            //data
            registrar.RegisterType<IAppointeeRepository<Appointee>, AppointeeRepository>();
            //registrar.RegisterType<IRepository<Appointer>, AppointerRepository>();

            //service
            //registrar.RegisterType<IAppointmentService, AppointmentService>();  
        }
    }
}
