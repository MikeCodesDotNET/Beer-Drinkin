using System;
using System.Threading.Tasks;
using BeerDrinkin.API;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service;

namespace BeerDrinkin.Core.ViewModels
{
    public class SignInViewModel
    {
        bool IsBusy { get; set; }

        public SignInViewModel()
        {
        }

        public async Task<UserItem> SignInUser()
        {
            return null;
        }

        string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 4)
                    password = value;

            }
        }

        string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value.Length > 3)
                    username = value;

            }
        }
    }
}

