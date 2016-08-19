using Example.Ui.FeatureTests.Selenium.Enums;

namespace Example.Ui.FeatureTests.Selenium
{
    public class SeleniumHelper
    {
        public static bool ReuseWebSession => false;

        public static void StartSelenium(SeleniumDriverType seleniumDriverType = SeleniumDriverType.Chrome, SeleniumExecutionEnviroment seleniumExecutionEnviroment = SeleniumExecutionEnviroment.Local)
        {
            SeleniumController.Instance.Start(seleniumDriverType, seleniumExecutionEnviroment);
        }
        
        public static void StopSeleniumIfNotReusingWebSession()
        {
            if (ReuseWebSession) return;
            StopSelenium();
        }

        public static void StopSelenium()
        {
            SeleniumController.Instance.Stop();
        }
    }
}
