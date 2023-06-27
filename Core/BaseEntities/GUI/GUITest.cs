using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Core.BaseEntities.GUI
{
    [AllureNUnit]
    public abstract class Test
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private AllureLifecycle _allure;

        [ThreadStatic] protected static Browser? Browser;
        protected WaitService? WaitService;

        [SetUp]
        public void Setup()
        {
            Browser = new Browser();
            WaitService = new WaitService(Browser.Driver);
            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Browser!.Driver!).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Browser!.CloseBrowser();
        }
    }
}