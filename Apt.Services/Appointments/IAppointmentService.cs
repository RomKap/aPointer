﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apt.Core;
using Apt.Core.Domain.Appointments;
using Apt.Core.Infrastructure;
 

namespace Apt.Services.Appointments
{
    public partial interface IAppointmentService
    {
        //IPagedList<Appointment> GetAllAppointments();

        //Appointment GetAppointment(int aptID);

        List<Appointee> GetAllAppointee();
        void AddAppointee(Appointee aptee);
        void AddOther(dynamic item);
        void DelAppointee(Appointee aptee);
        Appointee ViewAppointee(Appointee aptee);
        IRepository<Appointee> AppointeeRepo { get; set; }
    }
}
