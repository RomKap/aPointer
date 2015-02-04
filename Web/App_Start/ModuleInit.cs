using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using Apt.Core.Infrastructure;

using Apt.Services.Appointments;
using Apt.Services.AppointmentsProxy;
using Microsoft.Practices.Unity;

namespace Web.App_Start
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {      
            //from dll
            //registrar.RegisterType<IAppointmentService, AppointmentService>();

            //api
            registrar.RegisterType<IAppointmentService, AppointmentServiceClient>(new InjectionConstructor("http://localhost/aPointerAPI/api/Apt/"));
            //registrar.RegisterType<IAppointmentService, AppointmentServiceClient>(new InjectionConstructor("http://localhost:5977/api/Apt/"));
            registrar.RegisterType<IAppointmentService, AppointmentServiceClient>();   
        }
    }
}