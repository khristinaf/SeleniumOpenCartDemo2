using OpenCart.Framework.Extensions;
using OpenCart.UI.Models;
using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement EmailField => Driver.FindElement(By.Id("input-email"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("input-password"));
        private IWebElement LogInButton => Driver.FindElement(By.CssSelector("input[type='submit']"));
        private IWebElement FailedLoginError => Driver.FindElement(By.CssSelector(".alert.alert-danger"));

        public void LogIn(User user)
        {
            EmailField.ClearAndSendKeys(user.EMail);
            PasswordField.ClearAndSendKeys(user.Password);
            LogInButton.ClickExtended();
        }

        public string GetFailedLoginErrorMessage => FailedLoginError.Text;
    }
}