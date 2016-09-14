using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Core.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Version { get; set; }

        //Social
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string WebsiteUrl { get; set; }

        //Misc
        public string TermsOfUseUrl { get; set; }
    }
}
