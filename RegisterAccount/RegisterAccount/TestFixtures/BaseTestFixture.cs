using NUnit.Framework;
using OpenCart.Framework;
using System;

namespace RegisterAccount.TestFixtures
{
    public class BaseTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            Application.StartChromeDriver();
            Application.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Application.PageLoad);
            Application.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Application.ImplicitWait);
            Application.NavigateTo(TestData.TestData.HomePageUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Application.CloseBrowser();
        }
    }
}