using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Almanac.Service.Logging
{
    public class AppInsightLogger : ILog
    {
        
        private readonly TelemetryClient telemetryClient;
        public AppInsightLogger()
        {
            telemetryClient = new TelemetryClient();
        }

        public void LogInfo(string message)
        {
            LogInfo(message, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }

        public void LogInfo(string message, string category, string subCategory)
        {
            var dictionary = new Dictionary<string, string> { { "Category", category }, { "SubCategory", subCategory } };
            telemetryClient.TrackTrace(message,dictionary);
        }

        public void LogException(Exception ex)
        {
            LogException(ex,Guid.NewGuid().ToString(),Guid.NewGuid().ToString());
        }

        public void LogException(Exception ex, string category, string subCategory)
        {
            var dictionary = new Dictionary<string, string> {{"Category", category}, {"SubCategory", subCategory}};
            telemetryClient.TrackException(ex,dictionary);
           
        }
    }

    
}
