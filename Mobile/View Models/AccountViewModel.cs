using System;
using System.Threading.Tasks;
using BeerDrinkin.Service.Models;
using System.Net.Http;
using System.Collections.Generic;
using Akavache;
using System.Reactive.Linq; 
using System.Linq;
using Splat;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace BeerDrinkin.Core.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        HeaderInfo headerInfo;
        HeaderInfo HeaderInfo
        {
            get
            {
                return headerInfo;
            }
            set
            {    
                SetProperty(ref headerInfo, value);
                headerInfo = value;
            }
        }
        bool busy;

        public AccountViewModel()
        {
            this.PropertyChanged += async delegate(object sender, PropertyChangedEventArgs e)
            {
                if(e.PropertyName == "HeaderInfo")
                {
                    RefreshProperties();
                }
            };
        }

        void RefreshProperties()
        {
            var user = Client.Instance.BeerDrinkinClient.CurrentAccount;

            RatingsCount = headerInfo.Ratings.ToString();
            BeerCount = headerInfo.CheckIns.ToString();
            PhotoCount = headerInfo.Photos.ToString();
            FirstName = user.FirstName;
            AvararUrl = user.AvatarUrl;
            FullName = string.Format("{0} {1}", user.FirstName, user.LastName);

        }

        public async Task FetchData(bool forceRemoteRefresh = false)
        {   
            //Are we already running? 
            if (busy == true)
                return;
            busy = true;

            try
            {
                //We'll sometimes want to ensure we're loading data straight from the web rather than the cache
                if (forceRemoteRefresh == false)
                {
                    BlobCache.UserAccount.GetAndFetchLatest("headerInfo", GetRemoteHeaderInfo, null, null).Subscribe(header =>{
                        HeaderInfo = header;
                    });

                    BlobCache.UserAccount.GetAndFetchLatest("beerPhotosUrls", GetRemoteBeerPhotosUrls, null, null).Subscribe(photoUrls =>{
                        BeerPhotosUrls = photoUrls;
                    });
                }
                else
                {
                    HeaderInfo = await GetRemoteHeaderInfo();
                    BeerPhotosUrls = await GetRemoteBeerPhotosUrls();
                }
            }
            catch(Exception ex)
            {
                Xamarin.Insights.Report(ex);
            }
            finally
            {
                busy = false;
            }
        }

        List<string> beerPhotosUrls;
        public List<string> BeerPhotosUrls
        {
            get
            {                 
                return beerPhotosUrls;
            }
            set
            {
                SetProperty(ref beerPhotosUrls, value);
                beerPhotosUrls = value;
            }
        }

        async Task<List<string>> GetRemoteBeerPhotosUrls()
        {    
            //Fetch base64 strings for images for the currently signed in user. 
            var response = await Client.Instance.BeerDrinkinClient.GetPhotosForUser();

            if (response.Error == null)
            {               
                await BlobCache.UserAccount.InsertObject("beerPhotosUrls", response.Result);
                return response.Result;
            }
            return new List<string>();
        }

        async Task<HeaderInfo> GetRemoteHeaderInfo()
        {
            HeaderInfo header;

            var result = await Client.Instance.BeerDrinkinClient.GetUsersHeaderInfoAsync(Client.Instance.BeerDrinkinClient.GetUserId);
            header = result.Result;
            //Store it for next time
            await BlobCache.UserAccount.InsertObject("headerInfo", header);

            return header;
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

