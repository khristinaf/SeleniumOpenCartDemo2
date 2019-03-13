using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace OpenCart.Framework
{
    public static class Application
    {
        public static IWebDriver Driver { get; private set; }

        public static int ImplicitWait = 10;
        public static int PageLoad = 60;
        public static int SleepTimeClickMiliSeconds = 100;
        public static int SleepTimeActionMiliSeconds = 300;

        public static void StartChromeDriver() => Driver = new ChromeDriver();

        public static void NavigateTo(string url) =>
            Driver.Navigate().GoToUrl(url);

        public static void CloseBrowser() => Driver.Close();

        public static void WaitBeforeClick() =>
            Thread.Sleep(SleepTimeClickMiliSeconds);

        public static void WaitAfterAction() =>
            Thread.Sleep(SleepTimeActionMiliSeconds);
    }
}