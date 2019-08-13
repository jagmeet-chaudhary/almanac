using Almanac.Service.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Channels;
using Almanac.Service.Model;
using Almanac.Service.Storage;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Almanac.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var processor = new EventsProcessor(new TableStorage<Event>("Events", "DefaultEndpointsProtocol=https;AccountName=almanacstorage;AccountKey=OhHhKtuTjgATSkfG0lg4yUXCwgx3XYC8sYZzgDe4HlIY5zzULxhadF5Yb6zHl+yKwFyFv7+6yhZe/M6/p8iBjQ==;EndpointSuffix=core.windows.net"), new NotificationChannelFactory(new AppConfigSettingsProvider()));

            //processor.ProcessEvents();
            //System.Console.Read();
            //const string accountSid = "ACc1c7c4e33ef23acce9453ef39923b192";
            //const string authToken = "6389a0e7c883ab9fdddebe64f9c19fa2";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    body: "Your appointment is coming up on 5 Aug,2019 at Jagmeet",
            //    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            //    to: new Twilio.Types.PhoneNumber("whatsapp:+919980825120")
            //);
        }
    }
}
