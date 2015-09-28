using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BeerDrinkin.Forms.ViewModels;

namespace BeerDrinkin.Forms.Views
{
    public partial class WelcomeViewPage : ContentPage
    {
        public WelcomeViewPage()
        {
            InitializeComponent();

            BindingContext = new WelcomeViewModel();
        }

        private WelcomeViewModel ViewModel
        {
            get { return BindingContext as WelcomeViewModel; }
        }
    }
}

