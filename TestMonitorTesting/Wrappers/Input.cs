using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Wrappers
{
    internal class Input
    {
        private UIElement _uiElement;

        public Input(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public void Write(string text)
        {
            _uiElement.Click();
            _uiElement.Clear();
            _uiElement.SendKeys(text);
        }

        public void Click() => _uiElement.Click();

        public void Clear() => _uiElement.Clear();

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;

        public bool Enabled => _uiElement.Enabled;
    }
}