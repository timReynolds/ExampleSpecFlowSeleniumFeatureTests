using System;
using System.Diagnostics;
using System.IO;
using Example.Ui.FeatureTests.Selenium.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Example.Ui.FeatureTests.Selenium
{
    public class SeleniumController
    {
        public static SeleniumController Instance = new SeleniumController();
        public SeleniumDriverType DriverType { get; set; }
        public SeleniumExecutionEnviroment ExecutionEnviroment { get; set; }
        public IWebDriver Selenium { get; private set; }
        
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(1);

        public void Start(SeleniumDriverType driverType, SeleniumExecutionEnviroment executionEnviroment)
        {
            if (Selenium != null)
                return;

            switch (executionEnviroment)
            {
                case SeleniumExecutionEnviroment.Local:
                    Selenium = CreateLocalEnviromentSeleniumInstance(driverType);
                    break;
                default:
                    throw new NotSupportedException();
            }

            DriverType = driverType;
            ExecutionEnviroment = executionEnviroment;

            Selenium.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);
        }
        
        private IWebDriver CreateLocalEnviromentSeleniumInstance(SeleniumDriverType browser)
        {
            var startupPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            switch (browser)
            {
                case SeleniumDriverType.InternetExplorer:
                    return new InternetExplorerDriver(startupPath);
                case SeleniumDriverType.Firefox:
                    return new FirefoxDriver();
                case SeleniumDriverType.Chrome:
                    return new ChromeDriver(startupPath);
                case SeleniumDriverType.PhantomJs:
                    return new PhantomJSDriver();
                default:
                    throw new NotSupportedException();
            }
        }

        public void Stop()
        {
            if (Selenium == null)
                return;

            try
            {
                Selenium.Quit();
                Selenium.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            Selenium = null;
        }

        private ChromeOptions CreateChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");
            return options; 
        }
    }
}