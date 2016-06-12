using Foundation;
using System;
using UIKit;

namespace BeerDrinkin.iOS
{
    public partial class TrendingBeerCell : UITableViewCell
    {
        public TrendingBeerCell (IntPtr handle) : base (handle)
        {
        }

        public TrendingBeerCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) { }


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
        public UIImageView Image { get; set;}
        
    }
}