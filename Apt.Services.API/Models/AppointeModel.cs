using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apt.Services.API.Models
{
    public class AppointeModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}