using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Apt.Services.Appointments;
using Web.Models;
using Apt.Core.Domain.Appointments;

namespace Web.Controllers
{
    public class AppointmentController : Controller
    { 

        [Dependency]
        public IAppointmentService _AppointmentService { get; set; } 

        public AppointmentController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Appointee

        public ActionResult AllAppointee()
        {
           AppointeeViewModel apvm = new AppointeeViewModel();
           apvm.lstAppointee = _AppointmentService.GetAllAppointee();
           return View("../Appointments/Appointee", apvm);
        }

        [HttpPost]
        public ActionResult AllAppointee(AppointeeViewModel apvm)
        {
            Appointee aptee = new Appointee();
            aptee.FirstName = apvm.FirstName;
            aptee.LastName = apvm.LastName;
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = DateTime.Now;
            //_AppointmentService.AddAppointee(aptee);

            //non common method (use dapper directly rahter than dapperextension)
            _AppointmentService.AddDirect(aptee);

            return RedirectToAction("AllAppointee");
        }   

        public ActionResult AddAppointee()
        {
            return View("../Appointments/AddAppointee");
        }

        [HttpPost]
        public ActionResult AddAppointee(Appointee aptee)
        {
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = DateTime.Now;         
            _AppointmentService.AddAppointee(aptee);
            return View(aptee);
        }
   
        public ActionResult DelAppointee(int ID)
        {      
            Appointee aptee = new Appointee();
            aptee.ApteeID = ID;
            _AppointmentService.DelAppointee(aptee);


            AppointeeViewModel apvm = new AppointeeViewModel();
            apvm.lstAppointee = _AppointmentService.GetAllAppointee();
            return View("../Appointments/Appointee", apvm);
        }

        public ActionResult ViewAppointee(int ID)
        {
            Appointee aptee = new Appointee();
            aptee.ApteeID = ID;
            aptee = _AppointmentService.ViewAppointee(aptee);

            if (aptee == null)
                ViewBag.IsPresent = false;
            else
                ViewBag.IsPresent = true;

            return View("../Appointments/ViewAppointee", aptee);

        }

        

        #endregion Appointee

        #region Appointer

        #endregion Appointer
    }
}
