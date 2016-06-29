using System;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.ViewModels;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace BeerDrinkin.Core.ViewModels
{
    public class EnableUserLocationViewModel : ViewModelBase, IEnableUserLocationViewModel
    {
        public async Task<bool> RequestPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

            if (status == PermissionStatus.Granted)
                return true;

            if (status != PermissionStatus.Granted)
            {             
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                status = results[Permission.Location];      
            }

            //Lets double check the status
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status == PermissionStatus.Granted)
                return true;
            else
                return false;
        }

    }
}

