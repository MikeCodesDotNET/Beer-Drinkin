using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Service.Models
{
    public class BinaryUploadRequest
    {
        public string BinaryId { get; set; }
        public string BinaryType { get; set; }
        public string BinaryData { get; set; }
        public string UserId { get; set; }
    }
}
