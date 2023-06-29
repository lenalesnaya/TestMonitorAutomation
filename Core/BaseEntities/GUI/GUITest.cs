using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
[assembly: Parallelizable(ParallelScope.All)]
[assembly: LevelOfParallelism(4)]

namespace Core.BaseEntities.GUI
{
    [AllureNUnit]
    public abstract class Test
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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