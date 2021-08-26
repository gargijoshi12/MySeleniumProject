using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class AbstractPage
    {
        public readonly IWebDriver WebDriver;
        private int defaultTimeOut = 7000;
        protected AbstractPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        protected void Click(By selector, int? timeOut = null)
        {
            MouseHelper.Click(WebDriver, selector, GetDefaultTimeOut(timeOut));
        }

        protected void SendKeys(By selector, string keys, int? timeOut = null)
        {
            KeyBoardHelper.SendKeys(WebDriver, selector, keys, GetDefaultTimeOut(timeOut));
        }
        protected bool GetPresenceOf(By selector, int? timeOut = null)
        {
            try
            {
                WaitHelper.WaitForElement(WebDriver, ExpectedConditions.ElementIsVisible(selector), GetDefaultTimeOut(timeOut));
                LogHelper.logger.Log(Helpers.LogLevel.Info, $"Element identified by {selector} is found");
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.logger.Log(Helpers.LogLevel.Info, $"Element identified by {selector} is not found");
                return false;
            }
        }
        private int GetDefaultTimeOut(int? timeOut)
        {
            return timeOut == null
                ? defaultTimeOut
                : timeOut.Value;
        }
    }
}
