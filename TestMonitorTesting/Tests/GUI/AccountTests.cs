using Allure.Commons;
using Core.BaseEntities.GUI;
using Core.Utilites.Configuration;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SaucedemoTests;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Pages;

namespace TestMonitorTesting.Tests.GUI
{
    [TestFixture]
    internal class AccountTests : GUITest
    {
        [Test, Category("Positive"), Description("Upload an avatar")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("AccountGUITests")]
        [Regression]
        public void CreateTestSuite_WithStandartData()
        {
            var accountPage = new LoginPage(Browser!.Driver, true)
                .Login(Configurator.Admin!)
                .Header.OpenAccountPage();

            var previousImageSrc = accountPage.GetAvatarSrc();
            accountPage.LoadImage();
            var presentImageSrc = accountPage.GetAvatarSrc();

            Assert.That(presentImageSrc.Equals(previousImageSrc), Is.False);
        }
    }
}