using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Wrappers
{
    internal class Input
    {
        private UIElement _uiElement;

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;

        public bool Enabled => _uiElement.Enabled;

        public Input(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public Input(IWebDriver? driver, IWebElement webElement)
        {
            _uiElement = new UIElement(driver, webElement);
        }

        public void Write(string text)
        {
            _uiElement.Click();
            _uiElement.Clear();
            _uiElement.SendKeys(text);
        }

        public void Click() => _uiElement.Click();

        public void Clear() => _uiElement.Clear();

        public string GetAttribute(string attributeName) =>
            _uiElement.GetAttribute(attributeName);
    }
}