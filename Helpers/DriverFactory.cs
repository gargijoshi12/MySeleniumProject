using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Helpers
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver(DriverType driverType)
        {
            IWebDriver webDriver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    webDriver = CreateChrome();
                    break;
                case DriverType.ChromeHeadless:
                    webDriver = CreateChromeHeadless();
                    break;
                case DriverType.Firefox:
                    webDriver = CreateFirefox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null);
             }
            return webDriver;
        }

        private IWebDriver CreateChrome()
        {
            return new ChromeDriver(GetChromeDriverService());
        }

        private ChromeDriverService GetChromeDriverService()
        {
            return ChromeDriverService.CreateDefaultService(TestContext.CurrentContext.TestDirectory);
        }

        private IWebDriver CreateChromeHeadless()
        {
            throw new NotImplementedException();
        }

        private IWebDriver CreateFirefox()
        {
            throw new NotImplementedException();
        }
    }
}
