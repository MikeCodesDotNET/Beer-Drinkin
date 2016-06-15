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