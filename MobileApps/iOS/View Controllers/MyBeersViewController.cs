using System;
using System.Linq;
using System.Collections.Specialized;

using BeerDrinkin.Core.ViewModels;

using UIKit;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.iOS
{
    partial class MyBeersViewController : BaseViewController
    {
        readonly CheckInsViewModel viewModel = new CheckInsViewModel();
        MyBeersDataSource dataSource;
        List<Beer> beers;

        public MyBeersViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();



        }      
    }
}