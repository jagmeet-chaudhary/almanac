using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Channels;
using Almanac.Service.Events;
using Almanac.Service.Model;
using Almanac.Service.Storage;

namespace Almanac.Service.Events
{
    public class EventsProcessor : IEventsProcessor
    {
        private readonly ITableStorage<Event> eventStorage;
        private readonly INotificationChannelFactory channelFactory;
        public EventsProcessor(ITableStorage<Event> eventStorage, INotificationChannelFactory channelFactory)
        {
            this.eventStorage = eventStorage;
            this.channelFactory = channelFactory;
        }
        public void ProcessEvents()
        {
            var eventList =  eventStorage.Get();
            var selectedEvents = eventList.Where(x => DateTime.Today.Date >= x.EventDate.AddDays(-2).Date && DateTime.Today.Date <= x.EventDate.Date);
            var channels = channelFactory.GetNotificationChannels().ToList();
            foreach (var selectedEvent in selectedEvents)
            {
                channels.ForEach(c=> c.SendEventNotification(selectedEvent));
            }
        }
    }
}
