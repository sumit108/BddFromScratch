using OpenQA.Selenium;

namespace DemoBddSaucelab.Utilities
{
    public class ActionClass:BasePage
    {
        IWebDriver _driver;
        public ActionClass(IWebDriver driver) {
        _driver = driver;
        }
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public string GetText(By by)
        {
           return _driver.FindElement(by).Text;
        }
       
        public void SendText(By by, string text) {
            _driver.FindElement(by).SendKeys(text);
        }

        public void Click(By by)
        {
            _driver.FindElement(by).Click();
        }
    }
}
