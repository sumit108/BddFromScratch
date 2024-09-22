using OpenQA.Selenium;
using BoDi;
using DemoBddSaucelab.Utilities;

namespace DemoBddSaucelab.Hooks
{
    [Binding]
    internal class SpecFlowHooks:BasePage
    {
        private readonly IObjectContainer container;
        private IWebDriver _driver;
        public SpecFlowHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void DriverInitiate()
        {
            _driver = InitializeDriver();
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
