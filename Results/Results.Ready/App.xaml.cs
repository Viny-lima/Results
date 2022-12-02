using Autofac;
using Autofac.Features.ResolveAnything;
using Results.Operations.Core;
using Results.Operations.Data.DAO;
using Results.Operations.Data.Interfaces;
using Results.Operations.Data.Repository;
using Results.Operations.Events;
using Results.Ready.ViewModel;
using Results.Service.Services;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Results.Ready
{
    public sealed partial class App : Application
    {
        public static IContainer sdk { get; set; }

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            sdk = CreateSDK();
        }

        private static IContainer CreateSDK()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new PatientDAOEntity()).As<IPatientDAO>();
            builder.Register(c => new PatientRepository(patientDAO: c.Resolve<IPatientDAO>())).As<IPatientRepository>();
            builder.Register(c => new PatientService(repository: c.Resolve<IPatientRepository>())).As<IPatientService>();
            builder.Register(c => new MainViewModel()).As<MainViewModel>().SingleInstance();
            builder.Register(c => new HomeViewModel()).As<HomeViewModel>().SingleInstance();

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
                    rootFrame.Navigate(typeof(Home), e.Arguments);
                }
                // Ensure the current window is active
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
