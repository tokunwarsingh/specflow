using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowLivingDoc
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public static void BeforeScenario_anything()
        {
            // Initialize Chrome WebDriver
            var driver = new ChromeDriver();
            ScenarioContext.Current["WebDriver"] = driver;
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            // Quit WebDriver after scenario execution
            if (ScenarioContext.Current.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)ScenarioContext.Current["WebDriver"];

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
                    Arguments = string.Format(@"/C livingdoc test-assembly {0}.dll -t TestExecution.json & LivingDoc.html", "SpecFlowLivingDoc")
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


        [AfterStep]
        public static void AfterStep(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            if (ScenarioContext.Current.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)ScenarioContext.Current["WebDriver"];
              
                if (driver != null)
                {
                    var filename = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile(filename);                 
                    specFlowOutputHelper.AddAttachment(filename);
                }
            }
        }

    }
}