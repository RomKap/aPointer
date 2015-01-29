using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using Apt.Core.Infrastructure;

using Apt.Services.Appointments;

namespace Web.App_Start
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IAppointmentService, AppointmentService>();   
        }
    }
}