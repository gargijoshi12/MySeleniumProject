using NUnit.Framework;
using Pages.Google;

namespace Tests.MySeleniumProject.TestCases
{
    [TestFixture]
    public class SearchResultsTest : TestBase
    {
        [SetUp]
        public void Setup()
        {
            new GoogleHomePage(WebDriver)
                .EnterSearchQuery("Selenium")
                .ClickSearch();
        }

        [Test]
        public void SearchResults()
        {
            new GoogleSearchResultPage(WebDriver)
                .GetPresenceOfSearchResults(out bool isSearchResultsPresent);
            Assert.True(isSearchResultsPresent);
        }
    }
}