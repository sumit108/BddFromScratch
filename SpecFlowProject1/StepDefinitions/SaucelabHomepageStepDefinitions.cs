using DemoBddSaucelab.Data;
using DemoBddSaucelab.Utilities;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
//[assembly: Parallelizable(ParallelScope.All)]

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]

    public class SaucelabHomepageStepDefinitions : BasePage
    {
        IWebDriver _driver;
        ScenarioContext _scenarioContext;
        ActionClass actionClass;

        public SaucelabHomepageStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)// : base(browser)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            actionClass = new ActionClass(driver);
        }

        // Locators
        By ShoppingCartContainerId = By.Id("shopping_cart_container");

        [Given(@"I open saucelabs webiste")]
        public void GivenIOpenSaucelabsWebiste()
        {
            actionClass.NavigateToUrl(Constants.InventoryUrl);             
        }
        
        [Then(@"Sauce labs inventory product page opens")]
        public void ThenSauceLabsInventoryProductPageOpens()
        {
            ClassicAssert.IsTrue(_driver.FindElement(By.XPath("//div[@class='app_logo']")).Displayed, "Page not loaded");
        }

        [When(@"I add (.*) to cart")]
        public void WhenIAddItemToCart(string item)
        {
            _driver.FindElement(By.XPath("//div[text()='"+item+"']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
            _scenarioContext["cartSize"] = 2;
        }

        [Then(@"Item shoud get added")]
        public void ThenItemShoudGetAdded()
        {
            int cartItemsCount = Convert.ToInt32(actionClass.GetText(ShoppingCartContainerId));//("//div[@id='shopping_cart_container']")));
            ClassicAssert.AreEqual(cartItemsCount, _scenarioContext["cartSize"]);
        }

        [When(@"I add item's to cart")]
        public void WhenIAddItemToCart(Table table)
        {
            _scenarioContext["cartSize"] = 0;
            int counter=0;
            foreach (var row in table.Rows)
            {
                _driver.FindElement(By.XPath("//div[text()='" + row[0] + "']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
                _scenarioContext["cartSize"]=++counter;
            }
        }
    }
}
