using System.Data;
using DemoBddSaucelab.Data;
using DemoBddSaucelab.Utilities;
using OpenQA.Selenium;

namespace DemoBddSaucelab.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions : BasePage { 
        ActionClass actionClass;
        public LoginPageStepDefinitions(IWebDriver driver) //: base(browser)
    {
            actionClass = new ActionClass(driver);
    }

        // Locators
        By LoginInputBoxLocator = By.Id("user-name");
        By PasswordInputBoxLocator = By.Id("password");
        By LoginButtonLocator = By.Id("login-button");

        [Given(@"I open Saucelabs login page")]
        public void GivenIOpenSaucelabsLoginPage()
        {
            actionClass.NavigateToUrl(Constants.BaseUrl);
        }

        [When(@"I enter username as (.*) and password as (.*)")]
        public void WhenIEnterUsernameAsAndPasswordAs(string Username, string Password)
        {
            actionClass.SendText(LoginInputBoxLocator, Username);
            actionClass.SendText(PasswordInputBoxLocator, Password);
            actionClass.Click(LoginButtonLocator);
            }

        [When(@"I enter credentials")]
        public void WhenIEnterCredentials(Table table)
        {
            var dataTable = TableExtensions.ToDataTable(table);
            foreach (DataRow row in dataTable.Rows)
            {
               // loginPageClass.Login(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());                
            }
        }
    }
}
