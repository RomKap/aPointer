using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apt.Core.Domain.Appointments;
using Apt.Core;

namespace Web.Models
{
    public class AppointeeViewModel
    {
        [PrimaryKey]
        public int ApteeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public List<Appointee> lstAppointee { get; set; }

        public AppointeeViewModel()
        {            
        }
    }
}