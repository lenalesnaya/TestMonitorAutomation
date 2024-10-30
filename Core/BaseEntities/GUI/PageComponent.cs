using NLog;
using OpenQA.Selenium;

namespace Core.BaseEntities.GUI
{
    public abstract class PageComponent
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [ThreadStatic] protected static IWebDriver? Driver;

        public PageComponent(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract bool IsComponentExists();
    }
}