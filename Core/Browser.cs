using Core.Utilites.Configuration;
using OpenQA.Selenium;

namespace Core
{
    public class Browser
    {
        public IWebDriver? Driver { get; set; }

        public Browser()
        {
            Driver = Configurator.BrowserType!.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver?.Manage().Window.Maximize();
            Driver?.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public object? ExecuteScript(string script)
        {
            try
            {
                return ((IJavaScriptExecutor)Driver!).ExecuteScript(script);
            }
            catch
            {
                return null;
            }
        }

        public void SwitchToFirstWindow() =>
            Driver!.SwitchTo().Window(Driver.WindowHandles[0]);

        public void SwitchToLastWindow()
        {
            var windows = Driver!.WindowHandles;
            if (windows.Count > 1)
            {
                Driver.SwitchTo().Window(windows[^1]);
            }
        }

        public void CloseTab() =>
            Driver!.Close();

        public void CloseBrowser()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}