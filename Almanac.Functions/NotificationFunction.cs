using System;
using Almanac.Service.Channels;
using Almanac.Service.Events;
using Almanac.Service.Logging;
using Almanac.Service.Model;
using Almanac.Service.Storage;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Almanac.Functions
{
    public static class NotificationFunction
    {
        static NotificationFunction()
        {
            ApplicationHelper.Startup();
        }
        [FunctionName("NotificationFunction")]
        public static void Run([TimerTrigger("0 0 6 1/1 * * ",RunOnStartup = true)]TimerInfo myTimer, TraceWriter log,ExecutionContext context)
        {
            var logger = new AppInsightLogger();
            try
            {
                
                var settingsProvider = new SettingsProvider(context.FunctionAppDirectory, "Values");
                logger.LogInfo($"C# Timer trigger function executing at: {DateTime.Now}");
                var processor = new EventsProcessor(new TableStorage<Event>("Events", settingsProvider.GetSetting("StorageAccountConnectionString")), new NotificationChannelFactory(settingsProvider));

                processor.ProcessEvents();
                logger.LogInfo($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {

                logger.LogException(ex);
            }

        }
    }
}
