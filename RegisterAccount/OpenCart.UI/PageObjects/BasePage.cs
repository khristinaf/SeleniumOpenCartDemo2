using OpenCart.UI.Components;
using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public MyAccountDropDownNotLogged MyAccountDropDownNotLogged => new MyAccountDropDownNotLogged(Driver);
    }
}