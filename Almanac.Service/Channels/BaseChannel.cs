using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Logging;
using Almanac.Service.Model;
using Almanac.Service.Templates;

namespace Almanac.Service.Channels
{
    public abstract class BaseChannel : INotificationChannel
    {

        private  ITemplateProvider templateProvider;
        private ILog logger;
        private ISettingsProvider settingsProvider;
        protected BaseChannel(ITemplateProvider templateProvider, ILog logger,ISettingsProvider settingsProvider)
        {
            this.templateProvider = templateProvider;
            this.logger = logger;
            this.settingsProvider = settingsProvider;
        }
        public void SendEventNotification(Event e)
        {
            logger.LogInfo($"Sending notification for {e.ToString()} using channel {this.GetType()}");
            
            Send(e);
            logger.LogInfo($"Sent notification for {e.ToString()} using channel {this.GetType()}");
        }

        protected abstract void Send(Event  e);

        protected string GetTemplate(ChannelType channelType)
        {
            return templateProvider.GetTemplate(channelType);
        }

        protected void LogException(Exception ex)
        {
            logger.LogException(ex);
        }

        protected void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        protected string GetSettings(string key)
        {
            return settingsProvider.GetSetting(key);
        }

    }
}
