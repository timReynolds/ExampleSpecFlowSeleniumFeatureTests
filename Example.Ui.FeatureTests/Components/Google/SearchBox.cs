using Example.Ui.FeatureTests.Components.Web;
using Example.Ui.FeatureTests.Selenium;
using OpenQA.Selenium;

namespace Example.Ui.FeatureTests.Components.Google
{
    public class SearchBox : InputComponent
    {
        public SearchBox(SeleniumContext seleniumContext) : base(seleniumContext)
        {
            BySelector = By.Id("lst-ib");
        }
    }
}