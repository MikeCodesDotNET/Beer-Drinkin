using System;
using System.Threading.Tasks;
using BeerDrinkin.API;
using Xamarin;
using System.Collections.Generic;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Core.ViewModels
{
    public class SignUpViewModel
    {
        bool IsBusy { get; set; }

        public SignUpViewModel()
        {
        }

        public async Task<UserItem> SignUpUser()
        {
            return null;
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
                if (value.Length > 2)
                    firstName = value;
            }
        }

        string lastName;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length > 3)
                    lastName = value;
            }
        }

        string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (Helpers.RegexUtilities.IsValidEmail(value))
                    email = value;
            }
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

