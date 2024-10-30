using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Pages.Components
{
    internal class ProjectCard : PageComponent
    {
        private static readonly By LastProjectCardBy = By.CssSelector("div.columns:last-child");
        public UIElement LastProjectCard => new(Driver, LastProjectCardBy);

        public ProjectCard(IWebDriver driver) : base(driver) { }

        public override bool IsComponentExists()
        {
            throw new NotImplementedException();
        }
    }
}