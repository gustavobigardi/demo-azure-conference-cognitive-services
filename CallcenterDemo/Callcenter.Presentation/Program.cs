﻿using Callcenter.Domain.Handlers;
using Callcenter.Domain.Repositories;
using Callcenter.Infra.Database.DataContexts;
using Callcenter.Infra.Database.Repositories;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace Callcenter.Presentation
{
    static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BootstrapIoC();
            Application.Run(_container.GetInstance<FormMain>());
        }

        private static void BootstrapIoC()
        {
            _container = new Container();

            _container.Register<CallcenterDataContext>(Lifestyle.Singleton);

            _container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);

            _container.Register<UserHandler>(Lifestyle.Singleton);

            _container.Register<FormMain>(Lifestyle.Singleton);

            _container.Verify();
        }
    }
}
