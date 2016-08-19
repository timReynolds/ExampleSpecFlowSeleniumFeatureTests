using Example.Ui.FeatureTests.Extensions;
using Example.Ui.FeatureTests.Selenium;

namespace Example.Ui.FeatureTests.Components.Web
{
    public class InputComponent : WebComponent
    {
        protected InputComponent(SeleniumContext seleniumContext) : base(seleniumContext)
        {
        }

        public virtual void SetTextBoxValue(string value) => WebDriver.SetInputValue(BySelector, value);

        public virtual string TextBoxValue() => WebDriver.GetInputValue(BySelector);
    }
}