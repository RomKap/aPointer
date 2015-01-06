using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using Apt.Data;
using Apt.Core.Infrastructure;
using Apt.Core.Domain.Appointments;
using Apt.Data.Domain;
using Apt.Core;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Unity;
 

namespace Apt.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private IRepository<Appointee> _AppointeeRepo;

        [Microsoft.Practices.Unity.Dependency]
        public IRepository<Appointee> AppointeeRepo {
            get
            {
                return _AppointeeRepo;
            }
            set
            {
                _AppointeeRepo = value;
            }
        }

        public AppointmentService()
        {
           // AppointeeRepo = new AppointeeRepository();
        }

        public List<Appointee> GetAllAppointee()
        {
            List<Appointee> lst = new List<Appointee>();
            lst = _AppointeeRepo.FindAll().ToList();

            return lst;
        }

        public void AddAppointee(Appointee aptee)
        {
            _AppointeeRepo.Add(aptee);
        }

   
        public void AddOther(dynamic item)
        {
            //throw new NotImplementedException();
        }

        public void DelAppointee(Appointee aptee)
        {
            _AppointeeRepo.Remove(aptee);
        }

    }
}
