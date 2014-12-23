using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core.Domain.Appointments
{
    public partial class Schedule
    {
        public int SchID { get; set; }

        public int ApterID { get; set; }

        public int AddrID { get; set; }

        public string SchName { get; set; }

        public DateTime SchDate { get; set; }

        public DateTime SchTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int ModifiedBy { get; set; }
    }
}
