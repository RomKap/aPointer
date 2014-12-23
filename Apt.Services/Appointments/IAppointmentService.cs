using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core;
using Apt.Core.Domain.Appointments;
 

namespace Apt.Services.Appointments
{
    public partial interface IAppointmentService
    {
        //IPagedList<Appointment> GetAllAppointments();

        //Appointment GetAppointment(int aptID);

        List<Appointee> GetAllAppointee();
        void AddAppointee(Appointee aptee);
        void AddOther(dynamic item);
    }
}
