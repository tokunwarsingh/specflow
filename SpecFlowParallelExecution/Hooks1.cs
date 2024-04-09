using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowParallelExecution
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;
        public Hooks1(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario_anything()
        {
            // Initialize Chrome WebDriver
            var driver = new ChromeDriver();
            _scenarioContext.Add("WebDriver",driver);
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Quit WebDriver after scenario execution
            if (_scenarioContext.ContainsKey("WebDriver"))
            {
                var driver = (IWebDriver)_scenarioContext.Get<IWebDriver>("WebDriver");

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
                    Arguments = string.Format(@"/C livingdoc test-assembly {0}.dll -t TestExecution.json & LivingDoc.html", "SpecFlowParallelExecution")
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
        public void AfterStep(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            if (_scenarioContext.ContainsKey("WebDriver"))
            {
               var driver = (IWebDriver)_scenarioContext.Get<IWebDriver>("WebDriver");

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