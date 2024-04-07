using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace specflowHooks
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeScenario]
        public void BeforeScenario_anything()
        {
            // Initialize Chrome WebDriver
            var driver = new ChromeDriver();
            ScenarioContext.Current["WebDriver"] = driver;
        }

        [AfterStep]
        public void AfterStep_anything()
        {
            if (ScenarioContext.Current.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)ScenarioContext.Current["WebDriver"];
                // Capture screenshot after each scenario
                if (driver != null)
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
                    Console.WriteLine("Screenshot captured.");
                    driver.Quit();
                    Console.WriteLine("Browser closed.");
                }
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {            

            // Quit WebDriver after scenario execution
            if (ScenarioContext.Current.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)ScenarioContext.Current["WebDriver"];
                // Capture screenshot after each scenario
                if (driver != null)
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
                    Console.WriteLine("Screenshot captured.");
                    driver.Quit();
                    Console.WriteLine("Browser closed.");
                }

                driver.Quit();
            }
        }
    }
}