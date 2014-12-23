using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core.Domain.Appointments
{
    public partial class Appointment
    {
        public int AptID { get; set; }

        public int SchID { get; set; }

        public int ApteeID { get; set; }

        public DateTime AptTimeOriginal { get; set; }

        public DateTime AptTime { get; set; }

        public string RequestText { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int ModifiedBy { get; set; }
    }
}
