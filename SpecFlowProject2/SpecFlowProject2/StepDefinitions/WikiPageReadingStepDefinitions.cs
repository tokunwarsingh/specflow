using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class WikiPageReadingStepDefinitions
    {
        //private IWebDriver driver;

        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    driver = new ChromeDriver();
        //}

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    driver.Quit();
        //}

        [Given(@"I am on the wiki page for ""(.*)""")]
        public void GivenIAmOnTheWikiPageFor(string pageTitle)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>("WebDriver");
            // Navigate to the wiki page for the specified title
            driver.Navigate().GoToUrl($"https://en.wikipedia.org/wiki/{pageTitle}");
        }

        [Then(@"I should see the content of the page")]
        public void ThenIShouldSeeTheContentOfThePage()
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>("WebDriver");
            // Wait until the page content is loaded
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("mw-content-text")));

            // Get the page content
            IWebElement pageContent = driver.FindElement(By.Id("mw-content-text"));
            string content = pageContent.Text;

            // Output the content to the console
            Console.WriteLine("Page Content:");
            Console.WriteLine(content);
        }
    }
}
