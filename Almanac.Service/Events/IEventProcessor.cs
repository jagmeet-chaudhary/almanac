using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac.Service.Events
{
    public interface IEventsProcessor
    {
        void ProcessEvents();
    }
}
