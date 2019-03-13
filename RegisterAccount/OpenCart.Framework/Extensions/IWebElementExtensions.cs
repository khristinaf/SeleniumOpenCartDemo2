using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Framework.Extensions
{
    public static class IWebElementExtensions
    {
        public static void ClearAndSendKeys(this IWebElement element, string text)
        {
            element.ClickExtended();
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickExtended(this IWebElement element)
        {
            Application.WaitBeforeClick();
            element.Click();
        }

        public static void SelectDropdownItemByText(this IWebElement element, string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            element.ClickExtended();
            Application.WaitBeforeClick();
            new SelectElement(element).SelectByText(text);
        }

        public static string GetTextFromInputElement(this IWebElement element) =>
            element.GetAttribute("value");
    }
}