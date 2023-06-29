using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.BaseEntities.GUI
{
    public class UIElement : IWebElement
    {
        private readonly IWebElement _webElementImplementation;
        private readonly By? _selector;
        private readonly Actions _actions;

        [ThreadStatic] private static IWebDriver? _driver;
        protected WaitService WaitService;

        public string TagName => _webElementImplementation.TagName;

        public string Text => _webElementImplementation.Text;

        public bool Enabled => _webElementImplementation.Enabled;

        public bool Selected => _webElementImplementation.Selected;

        public Point Location => _webElementImplementation.Location;

        public Size Size => _webElementImplementation.Size;

        public bool Displayed => WaitService.GetVisibleElement(_selector!).Displayed;

        public UIElement(IWebDriver? driver, By @by)
        {
            _selector = by;
            _driver = driver;
            WaitService = new WaitService(driver);
            _actions = new Actions(driver);
            _webElementImplementation = driver!.FindElement(by);
        }

        public UIElement(IWebDriver? driver, IWebElement webElement)
        {
            _webElementImplementation = webElement;
            _driver = driver;
            WaitService = new WaitService(driver);
            _actions = new Actions(driver);
        }

        public IWebElement FindElement(By @by) =>
            _webElementImplementation.FindElement(@by);

        public ReadOnlyCollection<IWebElement> FindElements(By @by) =>
            _webElementImplementation.FindElements(@by);

        public void Clear() =>
            _webElementImplementation.Clear();

        // !Selected?
        public void SendKeys(string text)
        {
            if (!Displayed)
            {
                _actions.ScrollToElement(_webElementImplementation);
            }

            try
            {
                _webElementImplementation.SendKeys(text);
            }
            catch
            {
                _webElementImplementation.Click();
                _webElementImplementation.SendKeys(text);
            }
            
        }

        public void Submit() =>
            _webElementImplementation.Submit();

        public void Click()
        {
            if (!Displayed)
            {
                _actions.ScrollToElement(_webElementImplementation);
            }

            _webElementImplementation.Click();
        }

        public string GetAttribute(string attributeName) =>
            _webElementImplementation.GetAttribute(attributeName);

        public string GetDomAttribute(string attributeName) =>
            _webElementImplementation.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) =>
            _webElementImplementation.GetDomProperty(propertyName);

        public string GetCssValue(string propertyName) =>
            _webElementImplementation.GetCssValue(propertyName);

        public ISearchContext GetShadowRoot() =>
            _webElementImplementation.GetShadowRoot();

        public void Hover() =>
            _actions.MoveToElement(_webElementImplementation).Build().Perform();

        public void ContextClickToElement() =>
            new Actions(_driver)
              .MoveToElement(_webElementImplementation)
              .ContextClick()
              .Build()
              .Perform();

        public void AcceptAlert() =>
            _driver!.SwitchTo().Alert().Accept();
    }
}