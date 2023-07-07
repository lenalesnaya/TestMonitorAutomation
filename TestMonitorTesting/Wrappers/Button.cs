using AngleSharp.Dom;
using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Wrappers
{
    internal class Button
    {
        private UIElement _uiElement;

        public string Text => _uiElement.Text;
        public bool Displayed => _uiElement.Displayed;
        public bool IsClickable => _uiElement.IsClickable;
        public bool Enabled => _uiElement.Enabled;

        public Button(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public Button(IWebDriver? driver, IWebElement webElement)
        {
            _uiElement = new UIElement(driver, webElement);
        }

        public void Click() => _uiElement.Click();

        public bool IsDisabled()
        {
            try
            {
                return _uiElement.GetAttribute("disabled") != null;
            }
            catch
            {
                return false;
            }
        }

        public void KeyboardClick(string keys)
        {
            _uiElement.Hover();
            _uiElement.SendKeys(keys);
        }
    }
}