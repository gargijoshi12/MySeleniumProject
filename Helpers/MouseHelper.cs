using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Helpers
{
    public static class MouseHelper
    {
        public static void Click(IWebDriver webDriver, By selector, int timeout)
        {
            MoveTo(webDriver, selector, timeout);
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementIsVisible(selector), timeout);
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementToBeClickable(selector), timeout);
            ExceptionHelper.RetryIfStaleElementReferenceException(webDriver, w => w.FindElement(selector).Click());
            LogHelper.logger.Log(LogLevel.Info, $"Clicked element identified by [{selector}]");
        }

        public static void DoubleClick(IWebDriver webDriver, By selector, int timeout)
        {
            MoveTo(webDriver, selector, timeout);
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementIsVisible(selector), timeout);
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementToBeClickable(selector), timeout);
            ExceptionHelper.RetryIfStaleElementReferenceException(webDriver, w => new Actions(webDriver).ContextClick(webDriver.FindElement(selector)));
            LogHelper.logger.Log(LogLevel.Info, $"Clicked element identified by [{selector}]");
        }

        private static void MoveTo(IWebDriver webDriver, By selector, int timeout)
        {
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementIsVisible(selector), timeout);
        }
    }
}
