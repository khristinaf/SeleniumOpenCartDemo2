using OpenCart.Framework.Extensions;
using OpenCart.UI.Models;
using OpenQA.Selenium;

namespace OpenCart.UI.PageObjects
{
    public class RegisterAccountPage : BasePage
    {
        public RegisterAccountPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstName => Driver.FindElement(By.Id("input-firstname"));
        private IWebElement LastName => Driver.FindElement(By.Id("input-lastname"));
        private IWebElement EMail => Driver.FindElement(By.Id("input-email"));
        private IWebElement Telephone => Driver.FindElement(By.Id("input-telephone"));
        private IWebElement Fax => Driver.FindElement(By.Id("input-fax"));
        private IWebElement Company => Driver.FindElement(By.Id("input-company"));
        private IWebElement Address1 => Driver.FindElement(By.Id("input-address-1"));
        private IWebElement Address2 => Driver.FindElement(By.Id("input-address-2"));
        private IWebElement City => Driver.FindElement(By.Id("input-city"));
        private IWebElement PostCode => Driver.FindElement(By.Id("input-postcode"));
        private IWebElement Country => Driver.FindElement(By.Id("input-country"));
        private IWebElement RegionState => Driver.FindElement(By.Id("input-zone"));
        private IWebElement Password => Driver.FindElement(By.Id("input-password"));
        private IWebElement PasswordConfirm => Driver.FindElement(By.Id("input-confirm"));
        private IWebElement PolicyCheckbox => Driver.FindElement(By.CssSelector("input[type = 'checkbox'][name = 'agree']"));
        private IWebElement ContinueButton => Driver.FindElement(By.CssSelector(".btn.btn-primary"));
        private IWebElement FirstNameError => Driver.FindElement(By.CssSelector("#input-firstname + .text-danger"));
        private IWebElement LastNameError => Driver.FindElement(By.CssSelector("#input-lastname + .text-danger"));
        private IWebElement EMailError => Driver.FindElement(By.CssSelector("#input-email + .text-danger"));
        private IWebElement TelephoneError => Driver.FindElement(By.CssSelector("#input-telephone + .text-danger"));
        private IWebElement FAddress1Error => Driver.FindElement(By.CssSelector("#input-address-1 + .text-danger"));
        private IWebElement CityError => Driver.FindElement(By.CssSelector("#input-city + .text-danger"));
        private IWebElement PostCodeError => Driver.FindElement(By.CssSelector("#input-postcode + .text-danger"));
        private IWebElement RegionStateError => Driver.FindElement(By.CssSelector("#input-zone + .text-danger"));
        private IWebElement PasswordError => Driver.FindElement(By.CssSelector("#input-password + .text-danger"));
        private IWebElement PasswordConfirmError => Driver.FindElement(By.CssSelector("#input-confirm + .text-danger"));
        private IWebElement ErrorMessage => Driver.FindElement(By.CssSelector(".alert.alert-danger"));

        public void FillUserDataAndContinue(User user)
        {
            FillMandatoryFields(user);
            FillNotMandatoryFields(user);
            ClickPolicyCheckbox();
            ClickContinueButton();
        }

        public void ClickContinueButton() => ContinueButton.ClickExtended();

        public void ClickPolicyCheckbox() => PolicyCheckbox.ClickExtended();

        public void FillMandatoryFields(User user)
        {
            FirstName.ClearAndSendKeys(user.FirstName);
            LastName.ClearAndSendKeys(user.LastName);
            EMail.ClearAndSendKeys(user.EMail);
            Telephone.ClearAndSendKeys(user.Telephone);
            Company.ClearAndSendKeys(user.Company);
            Address1.ClearAndSendKeys(user.Address1);
            City.ClearAndSendKeys(user.City);
            PostCode.ClearAndSendKeys(user.PostCode);
            Country.SelectDropdownItemByText(user.Country);
            RegionState.SelectDropdownItemByText(user.RegionState);
            Password.ClearAndSendKeys(user.Password);
            PasswordConfirm.ClearAndSendKeys(user.PasswordConfirm);
        }

        public void FillNotMandatoryFields(User user)
        {
            Fax.ClearAndSendKeys(user.Fax);
            Company.ClearAndSendKeys(user.Company);
            Address2.ClearAndSendKeys(user.Address2);
        }

        public void SendKeysPasswordConfirm(string text) => PasswordConfirm.SendKeys(text);

        public void ClearAndFillEmail(string text) => EMail.ClearAndSendKeys(text);

        public string GetFirstNameErrorMessage => FirstNameError.Text;
        public string GetLastNameErrorMessage => LastNameError.Text;
        public string GetEMailErrorMessage => EMailError.Text;
        public string GetTelephoneErrorMessage => TelephoneError.Text;
        public string GetFAddress1ErrorMessage => FAddress1Error.Text;
        public string GetCityErrorMessage => CityError.Text;
        public string GetPostCodeErrorMessage => PostCodeError.Text;
        public string GetRegionStateErrorMessage => RegionStateError.Text;
        public string GetPasswordErrorMessage => PasswordError.Text;
        public string GetPasswordConfirmErrorMessage => PasswordConfirmError.Text;
        public string GetErrorMessage => ErrorMessage.Text;
    }
}