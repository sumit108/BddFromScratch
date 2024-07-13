using DemoBddSaucelab.Pages;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
//[assembly: Parallelizable(ParallelScope.All)]

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]

    public class SaucelabHomepageStepDefinitions : BaseTest
    {
        IWebDriver driver;
        ScenarioContext _scenarioContext;
        public SaucelabHomepageStepDefinitions(IWebDriver browser, ScenarioContext scenarioContext) : base(browser)
        {
            driver = _driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I open saucelabs webiste")]
        public void GivenIOpenSaucelabsWebiste()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/inventory.html");             
        }
        
        [Then(@"Sauce labs inventory product page opens")]
        public void ThenSauceLabsInventoryProductPageOpens()
        {
            ClassicAssert.IsTrue(_driver.FindElement(By.XPath("//div[@class='app_logo']")).Displayed, "Page not loaded");
        }

        [When(@"I add (.*) to cart")]
        public void WhenIAddItemToCart(string item)
        {
            driver.FindElement(By.XPath("//div[text()='"+item+"']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
            _scenarioContext["cartSize"] = 2;
        }

        [Then(@"Item shoud get added")]
        public void ThenItemShoudGetAdded()
        {
            int cartItemsCount =Convert.ToInt32(driver.FindElement(By.XPath("//div[@id='shopping_cart_container']")).Text);
            ClassicAssert.AreEqual(cartItemsCount, _scenarioContext["cartSize"]);
        }

        [When(@"I add item's to cart")]
        public void WhenIAddItemToCart(Table table)
        {
            _scenarioContext["cartSize"] = 0;
            int counter=0;
            foreach (var row in table.Rows)
            {
                driver.FindElement(By.XPath("//div[text()='" + row[0] + "']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
                _scenarioContext["cartSize"]=++counter;
            }
        }

    }
}
