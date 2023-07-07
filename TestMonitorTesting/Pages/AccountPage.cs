using Core;
using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using System.Reflection;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class AccountPage : Page
    {
        private static readonly By AvatarComponentBy = By.ClassName("avatar-component");
        private static readonly By AvatarBy = By.CssSelector("img.is-rounded");
        private static readonly By ImageUploaderBy = By.XPath("//input[@type='file']");

        public UIElement AvatarComponent => new(Driver, AvatarComponentBy);
        public UIElement Avatar => new(Driver, AvatarComponent.FindElement(AvatarBy));

        public UIElement ImageUploader = new (Driver, ImageUploaderBy);

        protected override string EndPoint => "/my-account";

        public AccountPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public AccountPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return AvatarComponent.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void LoadImage()
        {
            var baseLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = baseLocation + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar
                                        + "Images"
                                        + Path.DirectorySeparatorChar +
                                        "ava.jpg";
            ImageUploader.SendKeys(path);
            Thread.Sleep(6000);
        }

        public string GetAvatarSrc()
        {
            return Avatar.GetAttribute("src");
        }
    }
}