using OpenQA.Selenium;

namespace Example.Ui.FeatureTests.Extensions
{
    public static class SearchContextExtensions
    {
        public static bool IsElementVisible(this ISearchContext browser, By by)
        {
            var element = browser.FindElements(by);
            return element.Count != 0 && element[0].Displayed;
        }

        public static bool IsElementVisibleAndEnabled(this ISearchContext browser, By by)
        {
            var element = browser.FindElements(by);
            if (element.Count == 0)
            {
                return false;
            }
            return element[0].Displayed && element[0].Enabled;
        }

        public static bool IsElementVisibleAndDisabled(this ISearchContext browser, By by)
        {
            var element = browser.FindElements(by);
            if (element.Count == 0)
            {
                return false;
            }
            return element[0].Displayed && !element[0].Enabled;
        }
    }
}