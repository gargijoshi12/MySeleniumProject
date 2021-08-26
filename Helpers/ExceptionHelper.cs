using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Helpers
{
    public static class ExceptionHelper
    {
        public static void RetryIfStaleElementReferenceException(IWebDriver webDriver, Action<IWebDriver> action)
        {
            const int maxattempts = 2;
            for (int currentAttempt = 1; currentAttempt <= maxattempts; currentAttempt++)
            {

                try
                {
                    Thread.Sleep(250);
                    action.Invoke(webDriver);
                    return;
                }
                catch (Exception e) when (e is StaleElementReferenceException || e is InvalidOperationException || e is WebDriverException && e.Message.Contains("is not clickable at point"))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Attempting to recover from {e.GetType().Name}");
                }
            }
        }
    }
}
