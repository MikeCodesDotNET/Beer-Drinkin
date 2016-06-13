using Foundation;
using System;
using UIKit;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverBeerResultCell : UITableViewCell
    {
        public DiscoverBeerResultCell (IntPtr handle) : base (handle)
        {
        }

        public DiscoverBeerResultCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) { }

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

        public string Brewery
        {
            get
            {
                return brewery.Text;
            }
            set
            {
                brewery.Text = value;
            }
        }

        public UIImageView Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
    }
}