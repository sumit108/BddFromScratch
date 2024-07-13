using OpenQA.Selenium;
using BoDi;
using DemoBddSaucelab.Drivers;

namespace DemoBddSaucelab.Hooks
{
    [Binding]
    internal class SpecFlowHooks
    {
        private readonly IObjectContainer container;

        public SpecFlowHooks(IObjectContainer container)
        {
            this.container = container;
        }
        public IWebDriver _driver;
        WebDriverClass driverClass = new WebDriverClass();

        [BeforeScenario]
        public void DriverInitiate()
        {
            _driver = driverClass.GetDriver();
            container.RegisterInstanceAs(_driver);
        }

        [AfterScenario]
        public void DriverDispose()
        {
            IWebDriver _driver = container.Resolve<IWebDriver>();

            _driver.Quit();
            _driver.Dispose();
        }


    }
}
