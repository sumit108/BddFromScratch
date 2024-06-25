using System;
using DemoBddSaucelab.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoBddSaucelab.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions : BaseTest { 
        IWebDriver driver;
        LoginPageClass loginPageClass;
        public LoginPageStepDefinitions(IWebDriver browser) : base(browser)
    {
        driver = _driver;
        loginPageClass = new LoginPageClass(driver);
    }

        
        [Given(@"I open Saucelabs login page")]
        public void GivenIOpenSaucelabsLoginPage()
        {
            driver.Navigate().GoToUrl("https://saucedemo.com/");
        }

        [When(@"I enter username as (.*) and password as (.*)")]
        public void WhenIEnterUsernameAsAndPasswordAs(string p1,string p2)
        {
            loginPageClass.Login(p1, p2);
        }
    }
}
