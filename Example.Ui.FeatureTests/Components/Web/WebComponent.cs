using Example.Ui.FeatureTests.Extensions;
using Example.Ui.FeatureTests.Selenium;
using OpenQA.Selenium;

namespace Example.Ui.FeatureTests.Components.Web
{
    public abstract class WebComponent
    {
        protected By BySelector { get; set; }
        protected readonly IWebDriver WebDriver;

        protected WebComponent(SeleniumContext seleniumContext)
        {
            WebDriver = seleniumContext.Selenium;
        }

        public bool IsElementVisible() => WebDriver.IsElementVisible(BySelector);

        public bool IsElementVisibleAndEnabled() => WebDriver.IsElementVisibleAndEnabled(BySelector);

        public bool IsElementVisibleAndDisabled() => WebDriver.IsElementVisibleAndDisabled(BySelector);

        public virtual void ChangeFocus() => WebDriver.FindElement(BySelector).SendKeys(Keys.Tab);
        
    }
}