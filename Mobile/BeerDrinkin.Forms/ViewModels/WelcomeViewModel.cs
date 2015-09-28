using System;

using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using BeerDrinkin.Service;
using Colour = BeerDrinkin.Shared.Colour;
using Strings = BeerDrinkin.Core.Helpers.Strings;


namespace BeerDrinkin.Forms.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {

        private Command connectToFacebook;

        public WelcomeViewModel()
        {
            Title = "Welcome";
        }

        #region "Bindable properties"

        public Color BackgroundColor
        {
            get
            {
                return Colour.Blue;
            }
        }

        public Color ConnectBackgroundColor
        {
            get
            {
                return Colour.FacebookBlue;
            }
        }

        public string WelcomeText
        {
            get
            {
                return Strings.WelcomeTitle;
            }
        }

        public string ConnectTitle
        {
            get
            {
                return Strings.WelcomeFacebookButton;
            }
        }

        public string Promise
        {
            get
            {
                return Strings.WelcomePromise;
            }
        }

        #endregion

       
        public Command ConnectToFacebook
        {
            get { return connectToFacebook ?? (connectToFacebook = new Command(async () => await ExecuteConnectToFacebookCommand())); }
        }

        //Connect to Azure using Facebook Auth.
        private async Task ExecuteConnectToFacebookCommand()
        {
            
        }
    }
}


