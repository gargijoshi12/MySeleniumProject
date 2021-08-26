using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Helpers
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElement(IWebDriver webDriver, Func<IWebDriver, IWebElement> waitFunction, int timeout)
        {
            var timeOutFotElement = TimeSpan.FromMilliseconds(timeout);
            new WebDriverWait(webDriver, timeOutFotElement).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return RetryIfStaleElementReferenceException(webDriver, w => new WebDriverWait(w, timeOutFotElement).Until(waitFunction));
        }

        private static T RetryIfStaleElementReferenceException<T>(IWebDriver webDriver, Func<IWebDriver, T> action)
        {
            const int maxattempts = 3;
            for (int currentAttempt = 1; currentAttempt <= maxattempts; currentAttempt++)
            {

                try
                {
                    Thread.Sleep(250);
                    return action.Invoke(webDriver);
                }
                catch (StaleElementReferenceException)
                {
                    if (currentAttempt >= 3)
                        throw;
                    Console.WriteLine($"Attempting from {nameof(StaleElementReferenceException)}");
                }
            }
            throw new Exception($"{nameof(StaleElementReferenceException)}coding error.");
        }
    }
}
