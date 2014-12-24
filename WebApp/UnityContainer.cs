using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

/// <summary>
/// This class can be deleted as we are using Unity.webforms package.
/// </summary>
namespace Unity.Web
{

    public static class HttpApplicationStateExtensions
    {
        private const string GlobalContainerKey = "EntLibContainer";

        public static IUnityContainer GetContainer(this HttpApplicationState appState)
        {
            appState.Lock();
            try
            {
                var myContainer = appState[GlobalContainerKey] as IUnityContainer;
                if (myContainer == null)
                {
                    myContainer = new UnityContainer();
                    appState[GlobalContainerKey] = myContainer;
                }
                return myContainer;
            }
            finally
            {
                appState.UnLock();
            }
        }
    }

    static class ContainerRegistrationsExtension
    {
        public static string GetMappingAsString(this ContainerRegistration registration)
        {
            string regName, regType, mapTo, lifetime;

            var r = registration.RegisteredType;
            regType = r.Name + GetGenericArgumentsList(r);

            var m = registration.MappedToType;
            mapTo = m.Name + GetGenericArgumentsList(m);

            regName = registration.Name ?? "[default]";

            lifetime = registration.LifetimeManagerType.Name;
            if (mapTo != regType)
            {
                mapTo = " -> " + mapTo;
            }
            else
            {
                mapTo = string.Empty;
            }
            lifetime = lifetime.Substring(0, lifetime.Length - "LifetimeManager".Length);

            return String.Format(  "+ {0}{1}  '{2}'  {3}", regType, mapTo, regName, lifetime);
        }

        private static string GetGenericArgumentsList(Type type)
        {
            if (type.GetGenericArguments().Length == 0)
                return string.Empty;

            string arglist = string.Empty;
            bool first = true;
            foreach (Type t in type.GetGenericArguments())
            {
                arglist += first ? t.Name : ", " + t.Name;
                first = false;
                if (t.GetGenericArguments().Length > 0)
                {
                    arglist += GetGenericArgumentsList(t);
                }
            }
            return "<" + arglist + ">";
        }
    }
}