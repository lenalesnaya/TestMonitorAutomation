using Core.Utilites.Configuration;
using NLog;
using OpenQA.Selenium;

namespace Core.BaseEntities.GUI
{
    public abstract class Page
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [ThreadStatic] protected static IWebDriver? Driver;
        protected static int WaitForPageLoadingTime = 60;

        protected abstract string EndPoint { get; }

        public Page(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        private void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Configurator.AppSettings.URL + EndPoint);
            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondsCounter = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (isPageOpenedIndicator && secondsCounter < WaitForPageLoadingTime)
            {
                Thread.Sleep(1000);
                secondsCounter++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }

        public abstract bool IsPageOpened();
    }
}