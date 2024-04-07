using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace specflowHooks.StepDefinitions
{
    [Binding]
    public class WikiPageReadingStepDefinitions
    {
        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("WebDriver");

        [Given(@"I am on the wiki page for ""(.*)""")]
        public void GivenIAmOnTheWikiPageFor(string pageTitle)
        {
            // Navigate to the wiki page for the specified title
            driver.Navigate().GoToUrl($"https://en.wikipedia.org/wiki/{pageTitle}");
        }

        [Then(@"I should see the content of the page")]
        public void ThenIShouldSeeTheContentOfThePage()
        {
            // Wait until the page content is loaded
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("mw-content-text")));

            // Get the page content
            IWebElement pageContent = driver.FindElement(By.Id("mw-content-text"));
            string content = pageContent.Text;

            // Output the content to the console
            Console.WriteLine("Page Content:");
            Console.WriteLine(content);
            //driver.Quit();
        }
    }
}
