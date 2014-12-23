using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apt.Services.Appointments;
using Apt.Core.Domain.Appointments;
using Spring.Context;
using Spring.Context.Support;
using System.Dynamic;

namespace WebApp
{
    public partial class _Default : System.Web.UI.Page
    {
         public IAppointmentService _AppointmentService;
         public IAppointmentService ApptService {
             set { _AppointmentService = value; }
             get { return _AppointmentService; }
         }

        protected void Page_Load(object sender, EventArgs e)
        {
            _AppointmentService = new AppointmentService();

            //IApplicationContext ctx = ContextRegistry.GetContext();
           // AppointmentService _AppointmentService = (AppointmentService)ctx.GetObject("testaspx");

            if (!IsPostBack)
            {
                BindGrid();
            }
        }    

        void BindGrid()
        {            
           
            List<Appointee> lst = _AppointmentService.GetAllAppointee();
            GRV1.DataSource = lst;
            GRV1.DataBind();
        }

        void AddAppointee()
        {           
            Appointee aptee = new Appointee();
            aptee.FirstName = txtFirstName.Text.Trim();
            aptee.LastName = txtLastName.Text.Trim();
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = null;
            _AppointmentService.AddAppointee(aptee);

            //dynamic items = new ExpandoObject();
            //items.FirstName = txtFirstName.Text.Trim();
            //items.LastName = txtLastName.Text.Trim();
            //_AppointmentService.AddOther(items);
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            AddAppointee();
            BindGrid();
        }

    }
}
