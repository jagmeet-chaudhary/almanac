using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Model;

namespace Almanac.Service.Channels
{
    public interface INotificationChannel
    {
        void SendEventNotification(Event e);
    }
}
