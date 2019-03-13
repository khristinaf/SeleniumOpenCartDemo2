using NUnit.Framework;
using OpenCart.Framework;
using OpenCart.UI.Models;
using static OpenCart.UI.OpenCartApp;

namespace RegisterAccount.TestFixtures
{
    [TestFixture]
    public class EditAccountTestFixture : BaseTestFixture
    {
        private User InitialUser;

        [SetUp]
        public void LogInNavigateToEditAccount()
        {
            InitialUser = TestData.TestData.ValidSymbols;
            HomePage.MyAccountDropDownNotLogged.NavigateToRegisterAccount();
            RegisterAccountPage.FillUserDataAndContinue(InitialUser);
            AccountCreatedPage.ClickEditAccountLink();
        }

        [Test]
        [TestCaseSource(typeof(TestData.TestData), "ValidUsers")]
        public void EditAccountPositive(User user)
        {
            EditAccountPage.FillUserDataAndContinue(user);
            Assert.AreEqual(TestData.TestData.AdditionalData.AccountUpdatedMessage, MyAccountPage.GetAccountUpdatedMessage);
            VerifyUserCorespondToInformationOnPage(user);
        }

        [Test]
        [TestCaseSource(typeof(TestData.TestData), "InvalidUsersAndErrorMessages")]
        public void EditAccountNegative(User user, ErrorMessages errorMessages)
        {
            EditAccountPage.FillUserDataAndContinue(user);
            VerifyErrorMessages(errorMessages);
            EditAccountPage.ClickBackButton();
            VerifyUserCorespondToInformationOnPage(InitialUser);
        }

        [Test]
        public void VerifyUserDataIsNotUpdatedWithExistingEmail()
        {
            User user = TestData.TestData.ValidSymbols;
            EditAccountPage.FillUserData(user);
            EditAccountPage.ClearAndFillEmail(TestData.TestData.AdditionalData.ExistingEmail);
            EditAccountPage.ClickContinueButton();
            Assert.AreEqual(TestData.TestData.AdditionalData.EmailAlreadyExistsError, EditAccountPage.GetErrorMessage);
            VerifyUserCorespondToInformationOnPage(user);
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
            }
            );
            Application.WaitAfterAction();
        }

        public void VerifyUserCorespondToInformationOnPage(User user)
        {
            MyAccountPage.ClickEditAccountLink();
            Assert.AreEqual(user.FirstName, EditAccountPage.GetFirstNameFieldText);
            Assert.AreEqual(user.LastName, EditAccountPage.GetLastNameFieldText);
            Assert.AreEqual(user.EMail, EditAccountPage.GetEMailFieldText);
            Assert.AreEqual(user.Telephone, EditAccountPage.GetTelephoneFieldText);
            Assert.AreEqual(user.Fax, EditAccountPage.GetFaxFieldText);
            Application.WaitAfterAction();
        }
    }
}