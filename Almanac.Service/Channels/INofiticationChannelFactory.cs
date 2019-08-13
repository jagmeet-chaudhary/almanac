using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Logging;
using Almanac.Service.Templates;

namespace Almanac.Service.Channels
{
    public interface INotificationChannelFactory
    {
        IList<INotificationChannel> GetNotificationChannels();
    }

    public  class NotificationChannelFactory : INotificationChannelFactory
    {
        private readonly ISettingsProvider settingsProvider;
        public NotificationChannelFactory(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }
        public IList<INotificationChannel> GetNotificationChannels()
        {
            return new List<INotificationChannel>()
            {
                new WhatsAppChannel(new DefaultTemplateProvider(),new AppInsightLogger(), settingsProvider),
                new ConsoleChannel(new DefaultTemplateProvider(),new AppInsightLogger(), settingsProvider)//,
                //new EmailChannel(new DefaultTemplateProvider(), new AppInsightLogger(),settingsProvider)
            };
        }
    }
}
