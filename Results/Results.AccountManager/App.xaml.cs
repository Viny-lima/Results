using Autofac;
using Autofac.Features.ResolveAnything;
using Results.AccountManager.Views;
using Results.Operations.Core;
using Results.Operations.Data.Connection;
using Results.Operations.Data.DAO;
using Results.Operations.Data.Entities;
using Results.Operations.Data.Interfaces;
using Results.Operations.Data.Repository;
using Results.Operations.Events;
using Results.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Results.AccountManager
{
    sealed partial class App : Application
    {
        public static IContainer sdk { get; set; }

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            ////Dependency Injection
            sdk = CreateSDK();
            //database
            new ManagerDatabase().CreateDatabase();
        }

        private static IContainer CreateSDK()
        {            
            var builder = new ContainerBuilder();

            builder.Register(c => new PatientDAOEntity()).As<IPatientDAO>();
            builder.Register(c => new PatientRepository(patientDAO: c.Resolve<IPatientDAO>())).As<IPatientRepository>();
            builder.Register(c => new PatientService(repository: c.Resolve<IPatientRepository>())).As<IPatientService>();

            IContainer container = builder.Build();
            return container;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(HomeView), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}
