using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.MySeleniumProject
{
    public class TestBase
    {
        protected IWebDriver WebDriver { get; set; }
        [SetUp]
        public void BaseSetup()
        {
            BrowserContext browserContext = BrowserContextfactory.CreateContext();
            WebDriver = browserContext.WebDriver;
            WebDriver.Url = browserContext.BaseURL.AbsoluteUri.ToString();
            WebDriver.Manage().Window.Maximize();
        }

    }
}
