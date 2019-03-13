using NUnit.Framework;
using OpenCart.UI.Models;
using System.Linq;
using static OpenCart.Framework.Utils.Json;

namespace RegisterAccount.TestData
{
    public static class TestData
    {
        public const string HomePageUrl = "http://192.168.95.129/opencart/upload/index.php?route=common/home";

        private static string ErrorMessagesPath = @"TestData/ErrorMessages/";
        private static string UsersPath = @"TestData/Users/";

        public static User ValidSymbols => DeserializeValidUser("ValidSymbols.json");
        public static User ValidBWLower => DeserializeValidUser("ValidBWLower.json");
        public static User ValidBWUpper => CreateUserWithLongFields(ValidBWLower,
            DeserializeUser("ValidBWUpper.json"));

        public static User EmptyFields => DeserializeUser("EmptyFields.json");
        public static User InvalidSymbols => DeserializeUser("InvalidSymbols.json");
        public static User InvalidTooLong => CreateUserWithLongFields(ValidBWLower,
            DeserializeUser("InvalidTooLongs.json"));
        public static User InvalidTooShort => DeserializeUser("InvalidTooShort.json");

        public static ErrorMessages InvalidLengthErrorMessages =>
            DeserializeErrorMessage("InvalidLength.json");
        public static ErrorMessages InvalidSymbolsErrorMessages =>
            DeserializeErrorMessage("InvalidSymbols.json");

        public static AdditionalData AdditionalData => DeserializeFromFile<AdditionalData>(@"TestData/AdditionalData.json");

        public static object[] ValidUsers =
        {
            new TestCaseData(ValidSymbols).SetName("ValidSymbols"),
            new TestCaseData(ValidBWLower).SetName("ValidBWLower"),
            new TestCaseData(ValidBWUpper).SetName("ValidBWUpper")
        };

        public static object[] InvalidUsersAndErrorMessages =
        {
            new TestCaseData(new object[] { EmptyFields, InvalidLengthErrorMessages }).SetName("EmptyFields"),
            new TestCaseData(new object[] { InvalidSymbols, InvalidSymbolsErrorMessages }).SetName("InvalidSymbols"),
            new TestCaseData(new object[] { InvalidTooLong, InvalidLengthErrorMessages }).SetName("InvalidTooLong"),
            new TestCaseData(new object[] { InvalidTooShort, InvalidLengthErrorMessages }).SetName("InvalidTooShort")
        };

        private static User DeserializeValidUser(string path)
        {
            User user = DeserializeUser(path);
            user.EMail = System.DateTime.Now.Ticks + user.EMail;
            return user;
        }

        private static User DeserializeUser(string path) =>
            DeserializeFromFile<User>(UsersPath + path);

        private static ErrorMessages DeserializeErrorMessage(string path) =>
            DeserializeFromFile<ErrorMessages>(ErrorMessagesPath + path);

        private static User CreateUserWithLongFields(User template, User counts)
        {
            User user = new User();

            user.FirstName = RepeatChar(template.FirstName, counts.FirstName);
            user.LastName = RepeatChar(template.LastName, counts.LastName);
            user.EMail = RepeatChar(template.EMail, counts.EMail).Substring(template.EMail.Length) + template.EMail;
            user.Telephone = RepeatChar(template.Telephone, counts.Telephone);
            user.Fax = RepeatChar(template.Fax, counts.Fax);

            user.Company = RepeatChar(template.Company, counts.Company);
            user.Address1 = RepeatChar(template.Address1, counts.Address1);
            user.Address2 = RepeatChar(template.Address2, counts.Address2);
            user.City = RepeatChar(template.City, counts.City);
            user.PostCode = RepeatChar(template.PostCode, counts.PostCode);
            user.Country = template.Country;
            user.RegionState = template.RegionState;

            user.Password = RepeatChar(template.Password, counts.Password);
            user.PasswordConfirm = RepeatChar(template.PasswordConfirm, counts.PasswordConfirm);

            return user;
        }

        private static string RepeatChar(string charSouce, string count)
        {
            if (charSouce.Length == 0) return string.Empty;
            return new string(Enumerable.Repeat(charSouce.Last(), int.Parse(count)).ToArray());
        }
    }
}