using OpenCart.Framework.Extensions;
using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class RightSidebarPage : BasePage
    {
        private IWebElement EditAccountLink => Driver.FindElement(By.CssSelector("#column-right a[href*='edit']"));

        public RightSidebarPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickEditAccountLink()
        {
            EditAccountLink.ClickExtended();
        }
    }
}