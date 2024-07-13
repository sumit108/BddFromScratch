using OpenQA.Selenium;

namespace DemoBddSaucelab.Pages
{
    internal class LoginPageClass:BaseTest
    {
        IWebDriver driver; 
        public LoginPageClass(IWebDriver browser) : base(browser)
        {
            driver = _driver; 
        }

         // Locators
        By LoginInputBoxLocator = By.Id("user-name");
        By PasswordInputBoxLocator = By.Id("password");
        By LoginButtonLocator = By.Id("login-button");

        public void Login(String Username, String Password)
        {
            driver.FindElement(LoginInputBoxLocator).SendKeys(Username);
            driver.FindElement(PasswordInputBoxLocator).SendKeys(Password);
            driver.FindElement(LoginButtonLocator).Click();
        }
    }

    
}
