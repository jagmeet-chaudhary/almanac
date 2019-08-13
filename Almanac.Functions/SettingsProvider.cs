using Almanac.Service;
using Microsoft.Extensions.Configuration;

namespace Almanac.Functions
{
    public class SettingsProvider  : ISettingsProvider
    {
        private string appDirectory;
        private string keyPrefix;
        private IConfigurationRoot config;
        

        public SettingsProvider(string appDirectory,string keyPrefix)
        {
            this.appDirectory = appDirectory;
            this.keyPrefix = keyPrefix;

            this.config = new ConfigurationBuilder().SetBasePath(appDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            //todo : Add memory cache or check how to cache the configurations
        }
        public string GetSetting(string key)
        {
            return config[$"{keyPrefix}:{key}"];
        }
    }
}