using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Apt.Core.Infrastructure;

using Apt.Core.Domain.Appointments;
using Apt.Data.Domain;
using Apt.Data.Common;
using Microsoft.Practices.Unity;

namespace Apt.Services
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            //********* un-comment only usable repositories *********

            //with MicroORM (Dapper)
            registrar.RegisterType<ICommonRepository<Appointee>, AppointeeRepository>();
            registrar.RegisterType<ICommonRepository<Appointer>, AppointerRepository>();

            //with Entity Framework
            //registrar.RegisterType<IDbContext, AptDbContext>(new InjectionConstructor("server=FORD\\sqlExpress;database=AppointDB;Trusted_Connection=True;"));
            //registrar.RegisterType<ICommonRepository<Appointee>, CommonRepositoryEF<Appointee>>();
            //registrar.RegisterType<ICommonRepository<Appointer>, CommonRepositoryEF<Appointer>>();
        }
    }
}
