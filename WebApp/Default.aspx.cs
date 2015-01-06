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
using Microsoft.Practices.Unity;
using Unity.Web;


namespace WebApp
{
    public partial class _Default : System.Web.UI.Page
    {
     
         [Dependency]
         public IAppointmentService _AppointmentService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {  
        
            if (!IsPostBack)
            {
                BindGrid();

                //IUnityContainer container = Application.GetContainer();   
                //foreach (ContainerRegistration item in container.Registrations)
                //{
                //    Response.Write(item.GetMappingAsString());
                //}
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

        protected void GRV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DelAppointee")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Appointee aptee = new Appointee();
                aptee.ApteeID = ID;
                _AppointmentService.DelAppointee(aptee);

                BindGrid();
            }
        }

    }
}
