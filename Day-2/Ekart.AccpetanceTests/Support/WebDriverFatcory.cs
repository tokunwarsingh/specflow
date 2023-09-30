using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

public class WebDriverFactory
{
    private static IWebDriver instance;
    private static readonly object lockObject = new object();

    private WebDriverFactory() { }

    public static IWebDriver Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = CreateWebDriver(BrowserType.Chrome);
                    }
                }
            }
            return instance;
        }
    }

    private static IWebDriver CreateWebDriver(
        BrowserType browserType,
        DriverOptions driverOptions = null,
        string executablePath = null,
        int maxRetries = 1,
        TimeSpan retryInterval = default)
    {
        if (retryInterval == default)
        {
            retryInterval = TimeSpan.FromSeconds(1); // Default retry interval of 2 seconds
        }

        IWebDriver driver = null;

        for (int retryCount = 0; retryCount < maxRetries; retryCount++)
        {
            try
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        if (driverOptions == null)
                        {
                            driverOptions = new ChromeOptions();
                        }
                        if (!string.IsNullOrEmpty(executablePath))
                        {
                            ChromeOptions chromeOptions = (ChromeOptions)driverOptions;
                            chromeOptions.BinaryLocation = executablePath;
                        }
                        driver = new ChromeDriver((ChromeOptions)driverOptions);
                        break;
                    case BrowserType.Firefox:
                        if (driverOptions == null)
                        {
                            driverOptions = new FirefoxOptions();
                        }
                        if (!string.IsNullOrEmpty(executablePath))
                        {
                            FirefoxOptions firefoxOptions = (FirefoxOptions)driverOptions;
                            firefoxOptions.BrowserExecutableLocation = executablePath;
                        }
                        driver = new FirefoxDriver((FirefoxOptions)driverOptions);
                        break;
                    case BrowserType.Edge:
                        if (driverOptions == null)
                        {
                            driverOptions = new EdgeOptions();
                        }
                        if (!string.IsNullOrEmpty(executablePath))
                        {
                            EdgeOptions edgeOptions = (EdgeOptions)driverOptions;
                            edgeOptions.BinaryLocation = executablePath;
                        }
                        driver = new EdgeDriver((EdgeOptions)driverOptions);
                        break;
                    // Add cases for other browsers as needed
                    default:
                        throw new ArgumentOutOfRangeException("browserType", "Unsupported browser type.");
                }

                // If we successfully create the driver, break out of the retry loop
                if (driver != null)
                {
                    break;
                }
            }
            catch (Exception)
            {
                // If an exception occurs, wait for the specified interval before retrying
                Thread.Sleep(retryInterval);
            }
        }

        if (driver == null)
        {
            throw new InvalidOperationException("Failed to create WebDriver after multiple retries.");
        }

        return driver;
    }
}

public enum BrowserType
{
    Chrome,
    Firefox,
    Edge
    // Add other browser types as needed
}


