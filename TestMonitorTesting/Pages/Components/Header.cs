using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Pages.Components
{
    internal class Header : PageComponent
    {
        public Header(IWebDriver driver) : base(driver) { }

        public static readonly By ProjectsLinkBy = By.CssSelector("a[href$='my-projects']");
        public static readonly By NavbarLinkBy = By.ClassName("navbar-link");
        private static readonly By MyAccountItemBy = By.CssSelector("a[href$='my-account']");

        public UIElement ProjectsLink => new(Driver, ProjectsLinkBy);
        public UIElement NavbarLink => new(Driver, NavbarLinkBy);
        public UIElement MyAccountItem => new(Driver, MyAccountItemBy);

        public override bool IsComponentExists()
        {
            return ProjectsLink.Displayed;
        }

        public ProjectsPage ClickProjectsLink()
        {
            ProjectsLink.ExecuteScript("arguments[0].click();");

            var projectsPage = new ProjectsPage(Driver);
            projectsPage.WaitForOpen();
            Logger.Info($"Go to {nameof(ProjectsPage)}");

            return new ProjectsPage(Driver);
        }

        public Header ClickNavbarLink()
        {
            NavbarLink.Click();
            return this;
        }

        public AccountPage ClickMyAccountItem()
        {
            MyAccountItem.Click();

            var accountPage = new AccountPage(Driver);
            accountPage.WaitForOpen();
            Logger.Info($"Go to {nameof(AccountPage)}");

            return new AccountPage(Driver);
        }

        public AccountPage OpenAccountPage() =>
            ClickNavbarLink()
            .ClickMyAccountItem();
    }
}