using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Wrappers
{
    internal class Button
    {
        private UIElement _uiElement;

        public Button(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public void Click() => _uiElement.Click();

        public void KeyboardClick(string key) => _uiElement.SendKeys(key);

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;

        public bool Enabled => _uiElement.Enabled;
    }
}