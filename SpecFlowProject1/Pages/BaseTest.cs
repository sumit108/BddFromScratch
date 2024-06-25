using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using DemoBddSaucelab.Drivers;
using OpenQA.Selenium;

namespace DemoBddSaucelab.Pages
{
    [Binding]
    public class BaseTest
    {
        protected IWebDriver _driver;
        //protected LoginPage LoginPage { get; }

        /*public SpecflowBaseTest()
        {
        }*/

        public BaseTest(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
