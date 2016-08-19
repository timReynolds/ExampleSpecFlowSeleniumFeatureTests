using Example.Ui.FeatureTests.Selenium.Enums;
using OpenQA.Selenium;

namespace Example.Ui.FeatureTests.Selenium
{
    public class SeleniumContext
    {     
        public IWebDriver Selenium => SeleniumController.Instance.Selenium;

        public SeleniumDriverType DriverType => SeleniumController.Instance.DriverType;

        public SeleniumExecutionEnviroment ExecutionEnviroment => SeleniumController.Instance.ExecutionEnviroment;
    }
}