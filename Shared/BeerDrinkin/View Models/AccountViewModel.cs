using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Core.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {

        public AccountViewModel()
        {
        }

        public async Task Reload()
        {
            var user = await Client.Instance.BeerDrinkinClient.Users.CurrentUser();
            var headerResult = await Client.Instance.BeerDrinkinClient.GetUsersHeaderInfoAsync(user.Id);
            var headerInfo = headerResult.Result;   

            RatingsCount = headerInfo.Ratings.ToString();
            BeerCount = headerInfo.CheckIns.ToString();
            PhotoCount = headerInfo.Photos.ToString();
            FirstName = user.FirstName;
            AvararUrl = user.AvatarUrl;
            FullName = string.Format("{0} {1}", user.FirstName, user.LastName);
        }

        #region Properties 

        string ratingsCount;
        public string RatingsCount
        {
            get
            {
                return ratingsCount;
            }
            set
            {
                SetProperty(ref ratingsCount, value);
                ratingsCount = value;
            }
        }

        string photosCount;
        public string PhotoCount
        {
            get
            {
                return photosCount;
            }
            set
            {
                SetProperty(ref photosCount, value);
                photosCount = value;
            }
        }

        string beerCount;
        public string BeerCount
        {
            get
            {
                return beerCount;
            }
            set
            {                
                SetProperty(ref beerCount, value);
                beerCount = value;
            }
        }

        string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {                
                SetProperty(ref firstName, value);
                firstName = value;
            }
        }

        string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {                
                SetProperty(ref fullName, value);
                fullName = value;
            }
        }

        string avatarUrl = string.Empty;
        public string AvararUrl
        {
            get
            {
                return avatarUrl;
            }
            set
            {                
                SetProperty(ref avatarUrl, value);
                avatarUrl = value;
            }
        }


        #endregion

    }
}

