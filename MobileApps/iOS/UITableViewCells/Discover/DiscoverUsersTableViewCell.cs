using Foundation;
using System;
using UIKit;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverUsersTableViewCell : UITableViewCell
    {
        public DiscoverUsersTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public DiscoverUsersTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) { }


        public string Name
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }

        public string Location
        {
            get
            {
                return location.Text;
            }
            set
            {
                location.Text = value;
            }
        }

        public UIImageView Image
        {
            get
            {
                return avatar;
            }
            set
            {
                avatar = value;
            }
        }

    }
}