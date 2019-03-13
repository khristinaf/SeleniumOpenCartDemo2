using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class MyAccountPage : RightSidebarPage
    {
        private IWebElement AccountUpdatedMessage => Driver.FindElement(By.CssSelector(".alert.alert-success"));

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetAccountUpdatedMessage => AccountUpdatedMessage.Text;
    }
}