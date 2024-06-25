using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
