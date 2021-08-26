using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pages
{
    public class BasePage : AbstractPage
    {
        public BasePage(IWebDriver webDriver) : base(webDriver){ }
    }
}
