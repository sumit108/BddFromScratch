using DemoBddSaucelab.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoBddSaucelab.Drivers

{
    internal class WebDriverClass
    {
        ReadAndParseJsonFileWithNewtonsoftJson readAndParseJsonFileWithNewtonsoftJson = new ReadAndParseJsonFileWithNewtonsoftJson("D:\\SpecFlowProject1\\SpecFlowProject1\\Config\\config.json");

        public IWebDriver GetDriver()
        {
            IWebDriver driver = null;
            var configJson = readAndParseJsonFileWithNewtonsoftJson.DeerializeObjectWithNewtonsoftJson();
            var options = new ChromeOptions();

            if (configJson.IsWindowMaximize.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--start-maximized");
            if (configJson.IsIncognito.Equals("yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--incognito");
            if (configJson.IsHeadless.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--headless");
            if (configJson.BrowserName == "Chrome")
                driver = new ChromeDriver(options);
            return driver;
        }
    }
}
