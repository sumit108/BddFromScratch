using DemoBddSaucelab.Properties;
using Newtonsoft.Json;

namespace DemoBddSaucelab.Utilities
{
    internal class ReadAndParseJsonFileWithNewtonsoftJson
    {
        private readonly string _configJsonFilePath;
        public ReadAndParseJsonFileWithNewtonsoftJson(string configJsonFilePath)
        {
            _configJsonFilePath = configJsonFilePath;
        }

        public ConfigJson DeerializeObjectWithNewtonsoftJson()
        {
            using StreamReader reader = new(_configJsonFilePath);
            var json = reader.ReadToEnd();
            ConfigJson configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            return configJson;
        }
    }
}
