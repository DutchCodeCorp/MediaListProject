using Microsoft.Extensions.Configuration;
using System;


namespace MediaFetcher.Configuration
{
    public class ConfigurationHandler
    {
        public IConfiguration Configuration;

        public ConfigurationHandler(string config_file_name = "appsettings.json")
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(config_file_name, optional: true, reloadOnChange: true)
                .Build();
        }

        public string GetConfigValue(string key) =>
            this.Configuration[key] ?? "";
    }
}
