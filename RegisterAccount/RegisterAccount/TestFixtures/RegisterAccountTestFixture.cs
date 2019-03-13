using NUnit.Framework;
using OpenCart.Framework;
using OpenCart.UI.Models;
using RegisterAccount.TestFixtures;
using static OpenCart.UI.OpenCartApp;

namespace RegisterAccount.Tests
{
    public class RegisterAccountTestFixture : BaseTestFixture
    {
        [SetUp]
        public void NavigateToRegisterAccount()
        {
            HomePage.MyAccountDropDownNotLogged.NavigateToRegisterAccount();
        }

        [Test]
        [TestCaseSource(typeof(TestData.TestData), "ValidUsers")]
        public void RegisterAccountPositive(User user)
        {
            RegisterAccountPage.FillUserDataAndContinue(user);
            VerifyUserExists(user);
        }

        [Test]
        [TestCaseSource(typeof(TestData.TestData), "InvalidUsersAndErrorMessages")]
        public void RegisterAccountNegative(User user, ErrorMessages errorMessages)
        {
            RegisterAccountPage.FillUserDataAndContinue(user);
            VerifyErrorMessages(errorMessages);
            VerifyUserNotExists(user);
        }

        [Test]
        public void VerifyUserWithOnlyMandatoryFieldsIsCreated()
        {
            User user = TestData.TestData.ValidSymbols;
            RegisterAccountPage.FillMandatoryFields(user);
            RegisterAccountPage.ClickPolicyCheckbox();
            RegisterAccountPage.ClickContinueButton();
            VerifyUserExists(user);
        }

        [Test]
        public void VerifyUserWithPolicyNotCheckedIsNotCreated()
        {
            User user = TestData.TestData.ValidSymbols;
            RegisterAccountPage.FillMandatoryFields(user);
            RegisterAccountPage.ClickContinueButton();
            Assert.AreEqual(TestData.TestData.AdditionalData.PrivacyPolicyError, RegisterAccountPage.GetErrorMessage);
            VerifyUserNotExists(user);
        }

        [Test]
        public void VerifyUserWithNotMatchingPasswordsIsNotCreated()
        {
            User user = TestData.TestData.ValidSymbols;
            RegisterAccountPage.FillMandatoryFields(user);
            RegisterAccountPage.SendKeysPasswordConfirm(TestData.TestData.AdditionalData.BadPasswordAdditionalChar);
            RegisterAccountPage.ClickPolicyCheckbox();
            RegisterAccountPage.ClickContinueButton();
            Assert.AreEqual(TestData.TestData.AdditionalData.PasswordConfirmError, RegisterAccountPage.GetPasswordConfirmErrorMessage);
            VerifyUserNotExists(user);
        }

        [Test]
        public void VerifyUserWithAlreadyExistingEmailIsNotCreated()
        {
            User user = TestData.TestData.ValidSymbols;
            RegisterAccountPage.FillMandatoryFields(user);
            RegisterAccountPage.ClearAndFillEmail(TestData.TestData.AdditionalData.ExistingEmail);
            RegisterAccountPage.ClickPolicyCheckbox();
            RegisterAccountPage.ClickContinueButton();
            Assert.AreEqual(TestData.TestData.AdditionalData.EmailAlreadyExistsError, RegisterAccountPage.GetErrorMessage);
            VerifyUserNotExists(user);
        }

        public void VerifyUserExists(User user)
        {
            Assert.AreEqual(TestData.TestData.AdditionalData.AccountCreatedHeader, AccountCreatedPage.GetAccountCreatedHeader);
            Application.WaitAfterAction();
        }

        public void VerifyUserNotExists(User user)
        {
            HomePage.MyAccountDropDownNotLogged.NavigateToLoginPage();
            LoginPage.LogIn(user);
            Assert.AreEqual(TestData.TestData.AdditionalData.FailedLoginErrorMessage, LoginPage.GetFailedLoginErrorMessage);
            Application.WaitAfterAction();
        }

        public void VerifyErrorMessages(ErrorMessages expectedErrorMessages)
        {
            Assert.Multiple(() =>
                {
                    if (expectedErrorMessages.FirstNameError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.FirstNameError, RegisterAccountPage.GetFirstNameErrorMessage);
                    if (expectedErrorMessages.LastNameError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.LastNameError, RegisterAccountPage.GetLastNameErrorMessage);
                    if (expectedErrorMessages.EMailError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.EMailError, RegisterAccountPage.GetEMailErrorMessage);
                    if (expectedErrorMessages.TelephoneError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.TelephoneError, RegisterAccountPage.GetTelephoneErrorMessage);
                    if (expectedErrorMessages.Address1Error != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.Address1Error, RegisterAccountPage.GetFAddress1ErrorMessage);
                    if (expectedErrorMessages.CityError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.CityError, RegisterAccountPage.GetCityErrorMessage);
                    if (expectedErrorMessages.PostCodeError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.PostCodeError, RegisterAccountPage.GetPostCodeErrorMessage);
                    if (expectedErrorMessages.RegionStateError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.RegionStateError, RegisterAccountPage.GetRegionStateErrorMessage);
                    if (expectedErrorMessages.PasswordError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.PasswordError, RegisterAccountPage.GetPasswordErrorMessage);
                    if (expectedErrorMessages.PasswordConfirmError != string.Empty)
                        Assert.AreEqual(expectedErrorMessages.PasswordConfirmError, RegisterAccountPage.GetPasswordConfirmErrorMessage);
                }
                );
            Application.WaitAfterAction();
        }
    }
}