using OpenQA.Selenium;

namespace Pages.Google
{
    public class GoogleHomePage : AbstractPage
    {
        public GoogleHomePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public GoogleSearchResultPage ClickSearch()
        {
            Click(By.XPath("(//input[@aria-label='Google Search'])[1]"));
            return new GoogleSearchResultPage(WebDriver);
        }

        public GoogleHomePage EnterSearchQuery(string query)
        {
            SendKeys(By.XPath("//input[@title='Search']"), query);
            return this;
        }

    }
}
