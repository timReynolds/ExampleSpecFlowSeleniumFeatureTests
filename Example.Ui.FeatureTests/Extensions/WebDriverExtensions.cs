using System;
using OpenQA.Selenium;

namespace Example.Ui.FeatureTests.Extensions
{
    public static class WebDriverExtensions
    {

        public const string UnableToFindElementException = "Unable to locate element by: {0}";

        public static string GetInputValue(this IWebDriver webDriver, By by)
        {
            var element = webDriver.FindElement(by);

            if (element == null)
            {
                throw new InvalidOperationException(string.Format(UnableToFindElementException, by));
            }

            var result = element.GetAttribute("value");

            return result;
        }

        public static void SetInputValue(this IWebDriver webDriver, By by, string text, bool trimEscape = true)
        {
            var element = webDriver.FindElement(by);

            if (element == null)
            {
                throw new InvalidOperationException(string.Format(UnableToFindElementException, by));
            }

            if (element.TagName != "input" && element.TagName != "textarea")
            {
                throw new InvalidOperationException($"Element is not a type of input, is: {element.TagName}");
            }

            element.Clear();
            element.SendKeys(text);
        }
    }
}