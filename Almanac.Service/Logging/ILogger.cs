using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac.Service.Logging
{
    public interface ILog
    {
        void LogInfo(string message);
        void LogInfo(string message, string category, string subCategory);
        void LogException(Exception ex);
        void LogException( Exception ex, string category, string subCategory);
    }
}
