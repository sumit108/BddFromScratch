    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBddSaucelab.StepDefinitions
{
        [Binding]
        public sealed class ScenarioContextExample
        {
            [Given("I have entered (.*) into the calculator")]
            public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
            {
                ScenarioContext.Current["FirstNumber"] = number;
            }

            [Given(@"I also have entered (.*) into the calculator")]
            public void GivenIAlsoHaveEnteredIntoTheCalculator(int number)
            {
                ScenarioContext.Current["SecondNumber"] = number;
            }

            [When("I press add")]
            public void WhenIPressAdd()
            {
                var firstNumber = (int)ScenarioContext.Current["FirstNumber"];
                var secondNumber = (int)ScenarioContext.Current["SecondNumber"];
                ScenarioContext.Current["Result"] = firstNumber + secondNumber;
            }

            [Then("the result should be (.*) on the screen")]
            public void ThenTheResultShouldBe(int total)
            {
                var result = ScenarioContext.Current["Result"];
                if (!result.Equals(total))
                {
                    throw new Exception("Total is not correct");
                }
                Console.Out.WriteLine("Test Passed");
            }
        }
    }
