using DemoBddSaucelab.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoBddSaucelab.Utilities
{
    public class BasePage
    {
        public IWebDriver InitializeDriver()
        {
            var readAndParseJsonFileWithNewtonsoftJson = new ReadAndParseJsonFileWithNewtonsoftJson(Constants.ConfigPath);

            IWebDriver _driver;
            var configJson = readAndParseJsonFileWithNewtonsoftJson.DeerializeObjectWithNewtonsoftJson();
            var options = new ChromeOptions();

            if (configJson.IsWindowMaximize.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--start-maximized");
            if (configJson.IsIncognito.Equals("yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--incognito");
            if (configJson.IsHeadless.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                options.AddArgument("--headless");
            if (configJson.BrowserName == "Chrome")
                _driver = new ChromeDriver(options);
            else
                _driver = new ChromeDriver(options);
            return _driver;
        }
    }
}
