using System;
using DemoBddSaucelab.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Support;
using TechTalk.SpecFlow;
//[assembly: Parallelizable(ParallelScope.All)]

namespace SpecFlowProject1.StepDefinitions
{
    
    [Binding]

    public class SaucelabHomepageStepDefinitions : BaseTest
    {
        IWebDriver driver;
        public SaucelabHomepageStepDefinitions(IWebDriver browser) : base(browser)
        {
            driver = _driver; 
        }

        [Given(@"I open saucelabs webiste")]
        public void GivenIOpenSaucelabsWebiste()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/inventory.html"); 
        //https://www.saucedemo.com/inventory.html
            
        }
        
        [Then(@"Sauce labs inventory product page opens")]
        public void ThenSauceLabsInventoryProductPageOpens()
        {
            Assert.IsTrue(_driver.FindElement(By.XPath("//div[@class='app_logo']")).Displayed, "Page not loaded");
        }

        [When(@"I add (.*) to cart")]
        public void WhenIAddItemToCart(string item)
        {
            driver.FindElement(By.XPath("//div[text()='"+item+"']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
            //driver.FindElement(By.XPath("//a[@id='item_4_title_link']//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
            //driver.FindElement(By.XPath("//button[@class='btn_primary btn_inventory']")).Click();
        }

        [Then(@"(.*) Item shoud get added")]
        public void ThenItemShoudGetAdded(string count)
        {
            string cartItemsCount = driver.FindElement(By.XPath("//div[@id='shopping_cart_container']")).Text;
            //string cartItemsCount = driver.FindElement(By.XPath("//span[@class='fa-layers-counter shopping_cart_badge']")).Text;
            Assert.AreEqual(cartItemsCount, count);        
        }

        //[Then(@"(.*) Item shoud get added")]
        //public void ThenItemShoudGetAdded(int p0)
        //{
        //    string cartItemsCount = driver.FindElement(By.XPath("//span[@class='fa-layers-counter shopping_cart_badge']")).Text;
        //    Assert.AreEqual(Convert.ToInt32(cartItemsCount), p0);
        //}
        [When(@"I add (.*) item's to cart")]
        public void WhenIAddItemToCart(int p0, Table table)
        {
            foreach (var row in table.Rows)
            {
                driver.FindElement(By.XPath("//div[text()='" + row[0] + "']//parent::a//parent::div//parent::div//button[contains(@class,'btn_inventory')]")).Click();
                //driver.FindElement(By.XPath("//div[text()='" + row[0] + "']//parent::a//parent::div[@class='inventory_item_label']//following-sibling::div//button")).Click();
            }
        }

    }
}
