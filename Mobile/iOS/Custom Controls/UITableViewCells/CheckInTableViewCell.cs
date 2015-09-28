using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
    partial class CheckInTableViewCell : UITableViewCell
    {
        public CheckInTableViewCell(IntPtr handle)
            : base(handle)
        {            
        }

        public CheckInTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {    
            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera) == false)
                btnSnapAPhoto.Enabled = false;
        }

      

        partial void btnSnapAPhoto_TouchUpInside(UIButton sender)
        {
            SnapPhoto();
        }

        int rating;

        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;

                if (rating > 0)
                    btnRateMinus.Hidden = false;
                else if (rating == 0)
                    btnRateMinus.Hidden = true;
                    

                if (rating < 10)
                    btnRatePlus.Hidden = false;
                else if (rating == 10)
                    btnRatePlus.Hidden = true;                
            }
        }



        partial void btnRateMinus_TouchUpInside(UIButton sender)
        {
            if (Rating > 0)
                Rating--;          
          
            lblRating.Text = string.Format("{0}/10", rating.ToString());
        }

        partial void btnRatePlus_TouchUpInside(UIButton sender)
        {
            if (Rating < 10)
            {
                Rating++;
            }

            lblRating.Text = string.Format("{0}/10", rating.ToString());
        }

        partial void btnCheckIn_TouchUpInside(UIButton sender)
        {
            DidCheckIn();
        }

        public delegate void CheckInHandler();

        public event CheckInHandler DidCheckIn;

        public delegate void SnapPhotoInHandler();

        public event SnapPhotoInHandler SnapPhoto;
       
    }
}
