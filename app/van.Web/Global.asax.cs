﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Castle.Windsor;
using MvcContrib.Castle;
using SharpArch.Data.NHibernate;
using SharpArch.Web.NHibernate;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.WindsorAdapter;
using SharpArch.Web.Areas;
using van.Web.Controllers;
using van.Data.NHibernateMaps;
using van.Web.CastleWindsor;

namespace van.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new AreaViewEngine());

            InitializeServiceLocator();

            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from 
        /// WindsorController to the container.  Also associate the Controller 
        /// with the WindsorContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            container.RegisterControllers(typeof(HomeController).Assembly);
            ComponentRegistrar.AddComponentsTo(container);

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            Exception ex = Server.GetLastError();
            ReflectionTypeLoadException reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }

        /// <summary>
        /// Due to issues on IIS7, the NHibernate initialization must occur in Init().
        /// But Init() may be invoked more than once; accordingly, we introduce a thread-safe
        /// mechanism to ensure it's only initialized once.
        /// 
        /// See http://msdn.microsoft.com/en-us/magazine/cc188793.aspx for explanation details.
        /// </summary>
        public override void Init()
        {
            base.Init();
            
            // this hack is used to allow the application run in Integrated pipeline mode.
            // Issue reference 75 
            // See http://code.google.com/p/sharp-architecture/issues/detail?id=75

            if (!hasInitBeenCalledOnce)
            {
                hasInitBeenCalledOnce = true;
                return;
            }

            // Only allow the NHibernate session to be initialized once
            if (!wasNHibernateInitialized)
            {
                lock (LockObject)
                {
                    if (!wasNHibernateInitialized)
                    {
                        NHibernateSession.Init(new WebSessionStorage(this),
                            new string[] { Server.MapPath("~/bin/van.Data.dll") },
                            new AutoPersistenceModelGenerator().Generate(),
                            Server.MapPath("~/NHibernate.config"));


                        wasNHibernateInitialized = true;
                    }
                }
            }
        }

        private static bool hasInitBeenCalledOnce = false;

        private static bool wasNHibernateInitialized = false;

        /// <summary>
        /// Private, static object used only for synchronization
        /// </summary>
        private static readonly object LockObject = new object();
    }
}