using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core.Domain.Appointments
{
   public partial class Queue
    {
        public int QueueID { get; set; }

        public int SchID { get; set; }

        public int AptID { get; set; }

        public int SortOrder { get; set; }

    }
}
