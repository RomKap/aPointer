using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Apt.Services.Appointments;
using System.Web.Mvc;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Web.App_Start.UnityConfig), "PostStart")]
namespace Web.App_Start
{
    public class UnityConfig
    {
        /// <summary>
        ///     Initializes the unity container when the application starts up.
        /// </summary>
        /// <remarks>
        ///		Do not edit this method. Perform any modifications in the
        ///		<see cref="RegisterDependencies" /> method.
        /// </remarks>
        internal static void PostStart()
        {
            IUnityContainer container = new UnityContainer();
            //HttpContext.Current.Application.SetContainer(container);

            RegisterDependencies(container);
        }

        /// <summary>
        ///		Registers dependencies in the supplied container.
        /// </summary>
        /// <param name="container">Instance of the container to populate.</param>
        private static void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IAppointmentService, AppointmentService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}