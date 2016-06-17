using System;
using BeerDrinkin.Core.ViewModels;
using Foundation;
using UIKit;
using SDWebImage;
using MikeCodesDotNET.iOS;
using Plugin.Connectivity;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.Utils;

namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UIViewController
    {
        IUserProfileViewModel viewModel;

        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            viewModel = ServiceLocator.Instance.Resolve<IUserProfileViewModel>();
        }
    }
}