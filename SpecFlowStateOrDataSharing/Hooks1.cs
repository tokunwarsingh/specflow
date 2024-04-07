using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Configuration;

namespace SpecFlowStateOrDataSharing
{
    [Binding]
    public sealed class Hooks1
    {     
        [BeforeScenario]
        public static void BeforeScenario_anything()
        {
            // Initialize Chrome WebDriver
            var driver = new ChromeDriver();
            ScenarioContext.Current["WebDriver"] = driver;
        }

        [AfterStep]
        public static void AfterStep(ISpecFlowOutputHelper specFlowOutputHelper)
        {           
            if (ScenarioContext.Current.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)ScenarioContext.Current["WebDriver"];
                // Capture screenshot after each scenario
                if (driver != null)
                {
                    var filename = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile(filename);
                  
                    specFlowOutputHelper.WriteLine($"![Alt text]({filename})");
                    specFlowOutputHelper.WriteLine($"<img src = '{filename}' />");
                    specFlowOutputHelper.AddAttachment(filename);
                }               
            }
        }

        [AfterScenario]
        public static void AfterScenario()
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

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
#if DEBUG
                using Process process = new();
                ProcessStartInfo startInfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = string.Format(@"/C livingdoc test-assembly {0}.dll -t TestExecution.json & LivingDoc.html", "SpecFlowStateOrDataSharing")
                };
                process.StartInfo = startInfo;
                process.Start();
#endif
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}