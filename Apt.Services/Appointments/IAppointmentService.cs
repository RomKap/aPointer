using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core;
using Apt.Core.Domain.Appointments;
using Apt.Core.Infrastructure;
using Apt.Data.Domain;
 

namespace Apt.Services.Appointments
{
    public partial interface IAppointmentService
    {
        //IPagedList<Appointment> GetAllAppointments();

        //Appointment GetAppointment(int aptID);

        List<Appointee> GetAllAppointee();
        void AddAppointee(Appointee aptee);
        void AddDirect(Appointee aptee);
        void DelAppointee(Appointee aptee);
        Appointee ViewAppointee(Appointee aptee);
        IAppointeeRepository<Appointee> AppointeeRepo { get; set; }
    }
}
