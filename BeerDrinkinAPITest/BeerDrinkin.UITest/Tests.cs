using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Reflection;

namespace BeerDrinkin.UITest
{
    [TestFixture()]
    public class Tests
    {
        Xamarin.UITest.iOS.iOSApp app = null;

        public string PathToIPA { get; set; }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            FileInfo fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.Parent.FullName;
            PathToIPA = Path.Combine(dir, "Mobile","iOS", "bin", "iPhoneSimulator", "Debug", "BeerDrinkiniOS.app");
        }

        [SetUp]
        public void SetUp()
        {
            try
            {
                // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
                // this works fine for local simulator testing though
               // app = ConfigureApp.iOS.AppBundle(PathToIPA).Debug().StartApp();

                app = ConfigureApp.iOS.InstalledApp("com.mikejames.beerdrinkin").StartApp();

                if(app == null) 
                    throw new Exception("something went wrong...");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test()]
        public void DemoSomethingInteresting()
        {
            //REPL
            app.Repl();
        }
    }
}




