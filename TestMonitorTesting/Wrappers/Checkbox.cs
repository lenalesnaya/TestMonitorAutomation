using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Wrappers
{
    internal class Checkbox
    {
        private UIElement _uiElement;

        public Checkbox(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public void Click() => _uiElement.Click();

        public void Select()
        {
            if (!Selected)
                Click();
        }

        public void Deselect()
        {
            if (Selected)
                Click();
        }

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;

        public bool Selected => _uiElement.Selected;

        public bool Enabled => _uiElement.Enabled;
    }
}