﻿using STOService;
using STOService.ImplementationsBD;
using STOService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace STOView
{
   public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
       public static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMainAdministrator>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDataBaseContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientService, ClientServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IResourceService, ResourceServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceService, ServiceServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDeliveryService, DeliveryServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceBD>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
