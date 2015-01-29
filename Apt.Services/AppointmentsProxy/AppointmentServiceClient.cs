using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core.Infrastructure;
using Apt.Services.Appointments;
using Apt.Core.Domain.Appointments;

namespace Apt.Services.AppointmentsProxy
{
    public class AppointmentServiceClient : WebClientWrapperBase, IAppointmentService
    {
        public AppointmentServiceClient()
            : base("http://localhost/aPointerAPI/api/Apt/")
        {
            //just for compatibility
        }

        public AppointmentServiceClient(string baseUrl) : base(baseUrl)
        {
        }

        #region IAppointmentService Members

        public List<Appointee> GetAllAppointee()
        {
            return GetAll<Appointee>("GetAllAppointee");
        }

        public void AddAppointee(Appointee aptee)
        {
            throw new NotImplementedException();
        }

        public void AddDirect(Appointee aptee)
        {
            throw new NotImplementedException();
        }

        public void DelAppointee(Appointee aptee)
        {
            throw new NotImplementedException();
        }

        public Appointee ViewAppointee(Appointee aptee)
        {
            throw new NotImplementedException();
        }

        public Data.Domain.ICommonRepository<Appointee> AppointeeRepo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
