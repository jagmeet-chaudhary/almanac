using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Logging;
using Almanac.Service.Model;
using Almanac.Service.Templates;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace Almanac.Service.Channels
{
    public class WhatsAppChannel : BaseChannel
    {
       
        public WhatsAppChannel(ITemplateProvider templateProvider, ILog logger, ISettingsProvider settingsProvider) : base(templateProvider, logger, settingsProvider)
        {
        }

        protected override void Send(Event e)
        {
            var template = GetTemplate(ChannelType.WhatsApp);
            var messageToSend = string.Format(template, e.DaysRemaining, e.EventDate, e.Celebration, e.DressCode.IfEmptyThen("NONE"), e.Material.IfEmptyThen("NONE"),
                e.TypeOfActivity.IfEmptyThen("NONE"));
            const string accountSid = "ACc1c7c4e33ef23acce9453ef39923b192";
            const string authToken = "6389a0e7c883ab9fdddebe64f9c19fa2";

            TwilioClient.Init(accountSid, authToken);
            var whatsAppNumbers = new List<string>() {"whatsapp:+919980825120", "whatsapp:+919538705175"};

            whatsAppNumbers.ForEach(x =>
            {
                MessageResource.Create(
                    body: messageToSend,
                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                    to: new Twilio.Types.PhoneNumber(x)
                );
            });
           

        }
    }
}
