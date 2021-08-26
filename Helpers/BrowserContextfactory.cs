using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class BrowserContextfactory
    {
        public static BrowserContext CreateContext()
        {
            return new BrowserContext
            {
                WebDriver = new DriverFactory().CreateDriver(DriverType.Chrome),
                BaseURL = new URLFactory().GetUri()
            };
        }
    }
}
