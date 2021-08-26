using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.Google
{
    public class GoogleSearchResultPage : AbstractPage
    {
        public GoogleSearchResultPage(IWebDriver webdriver) : base(webdriver) { }

        public GoogleSearchResultPage GetPresenceOfSearchResults(out bool isSearchResultsPresent)
        {
            isSearchResultsPresent = GetPresenceOf(By.Id("search"));
            return this;
        }
    }
}
