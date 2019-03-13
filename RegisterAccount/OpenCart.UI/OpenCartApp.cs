using OpenCart.UI.PageObjects;
using static OpenCart.Framework.Application;

namespace OpenCart.UI
{
    public static class OpenCartApp
    {
        public static HomePage HomePage => new HomePage(Driver);
        public static EditAccountPage EditAccountPage => new EditAccountPage(Driver);
        public static LoginPage LoginPage => new LoginPage(Driver);
        public static RegisterAccountPage RegisterAccountPage => new RegisterAccountPage(Driver);
        public static AccountCreatedPage AccountCreatedPage => new AccountCreatedPage(Driver);
        public static MyAccountPage MyAccountPage => new MyAccountPage(Driver);
    }
}