using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Logging;
using Almanac.Service.Model;
using Almanac.Service.Templates;


namespace Almanac.Service.Channels
{
    public class ConsoleChannel : BaseChannel
    {
        
        public ConsoleChannel(ITemplateProvider templateProvider, ILog logger, ISettingsProvider settingsProvider) : base(templateProvider, logger, settingsProvider)
        {
             
        }
    
        protected override void Send(Event e)
        {
            var template = GetTemplate(ChannelType.Console);
            string notificationMessage = string.Format("NOTIFICATION:" + template, e.EventDate, e.Celebration,
                e.DressCode.IfEmptyThen("NONE"), e.Material.IfEmptyThen("NONE"), e.TypeOfActivity.IfEmptyThen("NONE"),
                e.Theme, e.DaysRemaining);
            Console.WriteLine(notificationMessage);
            LogInfo(notificationMessage);
        }
    }
}
