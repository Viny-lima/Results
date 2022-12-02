using Autofac;
using Autofac.Features.ResolveAnything;
using Results.Operations.Core;
using Results.Operations.Data.Connection;
using Results.Operations.Data.DAO;
using Results.Operations.Data.Interfaces;
using Results.Operations.Data.Repository;
using Results.Service.Services;
using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Results.Notifier
{
    public sealed class AccountManagerAppService : IBackgroundTask
    {
        private IContainer sdk;
        private IPatientService patientService;
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
       
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            //Create Database Context
            new ManagerDatabase().CreateDatabase();

            //Create SDK
            sdk = CreateSDK();
            patientService = sdk.Resolve<IPatientService>();            

            // Get a deferral so that the service isn't terminated.
            this.backgroundTaskDeferral = taskInstance.GetDeferral();

            // Associate a cancellation handler with the background task.
            taskInstance.Canceled += OnTaskCanceled;

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request
            var messageDeferral = args.GetDeferral();        
            var messageReceived = args.Request.Message;
            var messageReturn = new ValueSet();

            string command = messageReceived["Command"] as string;
            int? patientID = messageReceived["ID"] as int ?;

            try
            {

                switch (command)
                {
                    case "Exams":
                    {
                            messageReturn.Add("Results", patientService.FindById(patientID.Value).Result);
                            messageReturn.Add("Status", "OK");
                            break;
                    }
                    default:
                    {
                            messageReturn.Add("Status", "Erro: Unknown command");
                            break;
                    }
                }                
            }
            catch(Exception e)
            {
                messageReturn.Add("Status", $"Erro: {e} ");
            }
            finally
            {                
                await args.Request.SendResponseAsync(messageReturn);
                messageDeferral.Complete();
            }


        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }

        private static IContainer CreateSDK()
        {

            var builder = new ContainerBuilder();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            builder.RegisterType<PatientDAOEntity>().As<IPatientDAO>().AsImplementedInterfaces();
            builder.RegisterType<PatientRepository>().As<IPatientRepository>().AsImplementedInterfaces();
            builder.RegisterType<PatientService>().As<IPatientService>().AsImplementedInterfaces();

            IContainer container = builder.Build();
            return container;
        }
    }
}
