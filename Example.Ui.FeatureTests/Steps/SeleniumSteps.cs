using System;
using System.IO;
using System.Xml.Linq;
using Example.Ui.FeatureTests.Selenium;
using TechTalk.SpecFlow;

namespace Example.Ui.FeatureTests.Steps
{
    [Binding]
    public class SeleniumSteps
    {
        private readonly SeleniumContext seleniumContext;

        public SeleniumSteps(SeleniumContext seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [Given(@"I have launched a browser and loaded google")]
        public void GivenIHaveLaunchedABrowserAndLoadedGoogle()
        {
            SeleniumHelper.StartSelenium();
            seleniumContext.Selenium.Navigate().GoToUrl("http://google.com");
        }
    }
}