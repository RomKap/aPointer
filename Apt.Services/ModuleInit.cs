using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Apt.Core.Infrastructure;
using Apt.Services.Appointments;
using Apt.Core.Domain.Appointments;
using Apt.Data.Domain;
using System.Data.Entity;
using Apt.Data;
using Microsoft.Practices.Unity;

namespace Apt.Services
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            //wihtout EF (with Dapper)
            registrar.RegisterType<IAppointeeRepository<Appointee>, AppointeeRepository>();        
            registrar.RegisterType<IRepository<Appointer>, AppointerRepository>();

            //with EF
            //registrar.RegisterType<IDbContext, AptDbContext>(new InjectionConstructor("server=FORD\\sqlExpress;database=AppointDB;Trusted_Connection=True;"));
            //registrar.RegisterType<IAppointeeRepository<Appointee>, AppointeeRepositoryEF>();

            //service
            registrar.RegisterType<IAppointmentService, AppointmentService>();    

    
        }
    }
}
