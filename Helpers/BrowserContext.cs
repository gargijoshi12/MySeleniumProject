using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class BrowserContext
    {
        public IWebDriver WebDriver { get; set; }
        public Uri BaseURL { get; set; }
    }
}
