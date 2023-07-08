using Core.BaseEntities.GUI;
using Core.Models;
using OpenQA.Selenium;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class LoginPage : Page
    {
        protected override string EndPoint => "";

        private static readonly By EmailInputBy = By.Id("email");
        private static readonly By PasswordInputBy = By.Id("password");
        private static readonly By LoginButtonBy = By.XPath("//button[contains(text(), 'Login')]");

        public Input EmailInput => new(Driver, EmailInputBy);
        public Input PasswordInput => new(Driver, PasswordInputBy);
        public Button LoginButton => new(Driver, LoginButtonBy);


        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public LoginPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return LoginButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public LoginPage SetEmail(string email)
        {
            EmailInput.Write(email);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            PasswordInput.Write(password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public ProjectsPage Login(User user)
        {
            TryToLogin(user);

            var projectsPage = new ProjectsPage(Driver);
            projectsPage.WaitForOpen();
            Logger.Info($"Go to {nameof(ProjectsPage)}");

            return projectsPage;
        }

        public LoginPage TryToLogin(User user) =>
                SetEmail(user.Username!).
                SetPassword(user.Password!).
                ClickLoginButton();

        public override string ToString() =>
            nameof(LoginPage);
    }
}