using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core
{
    public class WaitService
    {
        [ThreadStatic] protected static IWebDriver? Driver;
        private WebDriverWait _wait;

        public WaitService(IWebDriver? driver)
        {
            Driver = driver;
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement GetVisibleElement(By by)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message, e);
            }
        }

        public IWebElement GetVisibleElementByFluentWait(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver?>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}