using Core.Utilites.Configuration;
using NLog;
using OpenQA.Selenium;

namespace Core.BaseEntities.GUI
{
    public abstract class Page
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [ThreadStatic] protected static IWebDriver? Driver;
        protected WaitService? WaitService;
        protected const int WaitForPageLoadingTime = 60;

        protected abstract string EndPoint { get; }

        public Page(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        private void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Configurator.AppSettings.URL + EndPoint);
            WaitForOpen();
            Logger.Info($"Go to {this}");
        }

        public void WaitForOpen()
        {
            var secondsCounter = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (!isPageOpenedIndicator && secondsCounter < WaitForPageLoadingTime)
            {
                Thread.Sleep(1000);
                secondsCounter++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }

        public abstract bool IsPageOpened();
    }
}