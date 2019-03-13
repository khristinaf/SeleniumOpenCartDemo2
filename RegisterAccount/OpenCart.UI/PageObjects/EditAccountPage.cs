using OpenCart.Framework.Extensions;
using OpenCart.UI.Models;
using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class EditAccountPage : BasePage
    {
        public EditAccountPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstName => Driver.FindElement(By.Id("input-firstname"));
        private IWebElement LastName => Driver.FindElement(By.Id("input-lastname"));
        private IWebElement EMail => Driver.FindElement(By.Id("input-email"));
        private IWebElement Telephone => Driver.FindElement(By.Id("input-telephone"));
        private IWebElement Fax => Driver.FindElement(By.Id("input-fax"));
        private IWebElement BackButton => Driver.FindElement(By.CssSelector(".pull-left .btn.btn-default"));
        private IWebElement ContinueButton => Driver.FindElement(By.CssSelector(".btn.btn-primary"));
        private IWebElement ErrorMessage => Driver.FindElement(By.CssSelector(".alert.alert-danger"));

        public void FillUserDataAndContinue(User user)
        {
            FillUserData(user);
            ClickContinueButton();
        }

        public void FillUserData(User user)
        {
            FirstName.ClearAndSendKeys(user.FirstName);
            LastName.ClearAndSendKeys(user.LastName);
            EMail.ClearAndSendKeys(user.EMail);
            Telephone.ClearAndSendKeys(user.Telephone);
            Fax.ClearAndSendKeys(user.Fax);
        }

        public void ClickContinueButton() => ContinueButton.ClickExtended();

        public void ClickBackButton() => BackButton.ClickExtended();

        public void ClearAndFillEmail(string text) => EMail.ClearAndSendKeys(text);

        public string GetFirstNameFieldText => FirstName.GetTextFromInputElement();
        public string GetLastNameFieldText => FirstName.GetTextFromInputElement();
        public string GetEMailFieldText => EMail.GetTextFromInputElement();
        public string GetTelephoneFieldText => Telephone.GetTextFromInputElement();
        public string GetFaxFieldText => Fax.GetTextFromInputElement();
        public string GetErrorMessage => ErrorMessage.Text;
    }
}