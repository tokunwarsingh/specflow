using NUnit.Framework;

namespace SpecFlowDataTableAndScenarioOutline.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int Number1 = 0;
        int Number2 = 0;

        [Given(@"I have entered the following numbers into the calculator:")]
        public void GivenIHaveEnteredTheFollowingNumbersIntoTheCalculator(Table table)
        {
            foreach (var row in table.Rows)
            {
                Number1 = Convert.ToInt32(row["Number1"]);
                Number2 = Convert.ToInt32(row["Number2"]);
            }
            
        }

        [When(@"I press the add button")]
        public void WhenIPressTheAddButton()
        {
            
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(p0, Number1+Number2);
        }

        [Given(@"I have entered ""([^""]*)"" into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            Number1 = Convert.ToInt32(p0);
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            throw new PendingStepException();
        }

        [When(@"I add (.*) and (.*)")]
        public void WhenIAddAnd(int p0, int p1)
        {
            throw new PendingStepException();
        }




    }
}