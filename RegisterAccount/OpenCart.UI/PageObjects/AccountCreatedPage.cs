using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class AccountCreatedPage : RightSidebarPage
    {
        private IWebElement AccountCreatedHeader => Driver.FindElement(By.CssSelector("#content h1"));

        public AccountCreatedPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetAccountCreatedHeader => AccountCreatedHeader.Text;
    }
}