using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core.Domain.Appointments
{
   public partial class Appointee : BaseEntity
    {
       [PrimaryKey]
       public int ApteeID { get; set; }

       public string FirstName { get; set; }

       public string LastName { get; set; }

       public string Address1 { get; set; }

       public DateTime? CreatedOn { get; set; }

       public DateTime? ModifiedOn { get; set; }

    }

   [AttributeUsage(AttributeTargets.Property)]
   public class PrimaryKey : Attribute
   {
       public PrimaryKey()
       {
       }
   }
}
