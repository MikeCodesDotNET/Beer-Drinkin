using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Service.DataObjects;
using System.Data.SqlClient;

namespace Publican.ViewModels
{
    class UsersViewModel : ViewModelBase
    {
        public List<AccountItem> GetUsersList()
        {
            List<AccountItem> results = new List<AccountItem>();

            //Open connection to Azure DB. We're bypassong Mobile Services to deal with the raw data. What could go wrong...
            string connectionString = "";

            
                return results;
        }
    }
}
