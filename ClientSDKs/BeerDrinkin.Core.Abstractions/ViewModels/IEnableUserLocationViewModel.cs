using System;
using System.Threading.Tasks;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface IEnableUserLocationViewModel
    {
        Task<bool> RequestPermission();
    }
}

