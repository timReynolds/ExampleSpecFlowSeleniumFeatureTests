using Example.Ui.FeatureTests.Selenium;
using TechTalk.SpecFlow;

namespace Example.Ui.FeatureTests.Hooks
{
    [Binding]
    public class SeleniumHooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            SeleniumHelper.StopSeleniumIfNotReusingWebSession();
        }
    }
}