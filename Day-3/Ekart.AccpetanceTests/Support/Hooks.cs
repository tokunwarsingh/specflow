using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart.AccpetanceTests.Support
{

    [Binding]
    public class Hooks
    {
       static IWebDriver driver;

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //driver = WebDriverFactory.Instance;

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            driver = WebDriverFactory.Instance;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (driver != null)
            {
                WebDriverFactory.Instance.Quit();
            }
        }
    }
}
