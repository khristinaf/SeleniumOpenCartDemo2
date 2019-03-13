using OpenCart.Framework.Extensions;
using OpenQA.Selenium;

namespace OpenCart.UI.Components
{
    public class MyAccountDropDownNotLogged
    {
        private IWebDriver Driver;

        public MyAccountDropDownNotLogged(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement MyAccountDropdown => Driver.FindElement(By.CssSelector("#top-links .dropdown-toggle"));
        private IWebElement RegisterLink => Driver.FindElement(By.CssSelector("a[href *= 'register']"));
        private IWebElement LoginLink => Driver.FindElement(By.CssSelector("a[href *= 'login']"));

        public void NavigateToRegisterAccount()
        {
            MyAccountDropdown.ClickExtended();
            RegisterLink.ClickExtended();
        }

        public void NavigateToLoginPage()
        {
            MyAccountDropdown.ClickExtended();
            LoginLink.ClickExtended();
        }
    }
}