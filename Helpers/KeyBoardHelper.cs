using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Helpers
{
    public static class KeyBoardHelper
    {
        public static void SendKeys(IWebDriver webDriver, By selector,string keysToSend, int timeout)
        {
            WaitHelper.WaitForElement(webDriver, ExpectedConditions.ElementToBeClickable(selector), timeout);
            ExceptionHelper.RetryIfStaleElementReferenceException(webDriver, w => w.FindElement(selector).Clear());
            ExceptionHelper.RetryIfStaleElementReferenceException(webDriver, w => w.FindElement(selector).SendKeys(keysToSend));
            LogHelper.logger.Log(LogLevel.Info, $"Sent Keys element identified by [{selector}]");
        }
    }
}
