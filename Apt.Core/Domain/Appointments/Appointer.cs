using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core.Domain.Appointments
{
    public partial class Appointer : BaseEntity
    {
        [PrimaryKey]
        public int ApterID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
