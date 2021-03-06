﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Web.Http;
using Apt.Core.Domain.Appointments;
using Apt.Data.Domain;
using Apt.Services.API.Models;

namespace Apt.Services.API
{
    public class AptController : ApiController
    {    

        private ICommonRepository<Appointee> _AppointeeRepo;

        [Microsoft.Practices.Unity.Dependency]
        public ICommonRepository<Appointee> AppointeeRepo
        {
            get
            {
                return _AppointeeRepo;
            }
            set
            {
                _AppointeeRepo = value;
            }
        }

        
        [System.Web.Http.HttpGet]
        public string Hello()
        {
            return "Hello world";
        }

        #region Appointee

        [System.Web.Http.HttpGet]
        public List<Appointee> GetAllAppointee()
        {
            List<Appointee> lst = new List<Appointee>();
            lst = _AppointeeRepo.FindAll().ToList();

            return lst;
        }

        [System.Web.Http.HttpPost]
        public void AddAppointee(AppointeModel apteem) 
        {
            var context = HttpContext.Current;
            Appointee aptee = new Appointee();
            aptee.FirstName = apteem.FirstName;
            aptee.LastName = apteem.LastName;
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = DateTime.Now;

            _AppointeeRepo.Add(aptee);
            //OR
            //_AppointeeRepo.AddDirect(aptee);
        }

   

        [System.Web.Http.HttpGet]
        public void DelAppointee(int ID)
        {
            Appointee aptee = new Appointee();
            aptee.ApteeID = ID;
            _AppointeeRepo.Remove(aptee);
        }

        [System.Web.Http.HttpGet]
        public Appointee ViewAppointee(int ID)
        {
            Appointee aptee = new Appointee();
            aptee.ApteeID = ID;
            aptee = _AppointeeRepo.FindByID(aptee);

            return aptee;
        }
        #endregion Appointee

        #region Appointer

        //public void AddAppointer(Appointer apter)
        //{
        //    _AppointerRepo.Add(apter);
        //}
        #endregion Appointer

    }
}
