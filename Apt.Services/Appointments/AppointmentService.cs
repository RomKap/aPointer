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
        private ICommonRepository<Appointee> _AppointeeRepo;
        private ICommonRepository<Appointer> _AppointerRepo;

        [Microsoft.Practices.Unity.Dependency]
        public ICommonRepository<Appointee> AppointeeRepo
        {
            get
            {
                return _AppointeeRepo;
            }
            set
            {
                _AppointeeRepo = value;
            }
        }

        [Microsoft.Practices.Unity.Dependency]
        public ICommonRepository<Appointer> AppointerRepo
        {
            get
            {
                return _AppointerRepo;
            }
            set
            {
                _AppointerRepo = value;
            }
        }

        public AppointmentService()
        {
           // AppointeeRepo = new AppointeeRepository();
        }

        #region Appointee

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

        public void AddDirect(Appointee aptee)
        {
            _AppointeeRepo.AddDirect(aptee);
        }

        public void DelAppointee(Appointee aptee)
        {
            _AppointeeRepo.Remove(aptee);
        }

        public Appointee ViewAppointee(Appointee aptee)
        {
            return _AppointeeRepo.FindByID(aptee);
        }
        #endregion Appointee

        #region Appointer

        public void AddAppointer(Appointer apter)
        {
            _AppointerRepo.Add(apter);
        }
        #endregion Appointer

    }
}
