using System.Reflection;
using Example.Ui.FeatureTests.Components.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Example.Ui.FeatureTests.Steps
{
    [Binding]
    public class GoogleSteps
    {
        private readonly SearchBox searchBox;

        public GoogleSteps(SearchBox searchBox)
        {
            this.searchBox = searchBox;
        }

        [Then(@"the search box should be visible")]
        public void ThenTheSearchBoxShouldBeVisible()
        {
            Assert.IsTrue(searchBox.IsElementVisible());
        }
    }
}