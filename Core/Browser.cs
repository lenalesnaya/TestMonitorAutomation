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
            Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public static object? ExecuteScript(IWebDriver driver, string script)
        {
            try
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(script);
            }
            catch
            {
                return null;
            }
        }

        public void AcceptAlert() =>
            Driver!.SwitchTo().Alert().Accept();

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