using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace BeerDrinkin.iOS.TestCloud
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class WelcomeTests
    {
        IApp app;
        Platform platform;

        public WelcomeTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void CanSignIn()
        {
            app.WaitForElement(x => x.Text("Connect with Facebook"));
            app.Screenshot("Then I see the Facebook auth button");

            app.Tap(x => x.Text("Connect with Facebook"));
            app.Screenshot("Then I tap 'Connect with Facebook' button");

            app.WaitForElement(x => x.Class("UIWebView"));
            app.Tap(x => x.Class("UIWebView").Css("INPUT._56bg._4u9z._5ruq"));
            app.Screenshot("Tapped on username");

            app.Tap(x => x.Class("UIWebView").Css("INPUT._56bg._4u9z._5ruq"));
            app.Screenshot("Tapped on view with class: UIWebView");

            app.EnterText(x => x.Class("UIWebView").Css("INPUT._56bg._4u9z._5ruq"), "cdxjrvo_carrierowitz_1467225980@tfbnw.net");
            app.EnterText(x => x.Class("UIWebView").Css("INPUT#u_0_2"), "ilovebeer");
            app.Tap(x => x.Class("UIWebView").Css("BUTTON#u_0_6"));

            app.WaitForElement(x => x.Text("Picture Search"));
            app.Screenshot("Finished Signing In");
        }
    }
}

