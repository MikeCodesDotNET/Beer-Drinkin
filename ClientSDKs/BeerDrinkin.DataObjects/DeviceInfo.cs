using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class DeviceInfo : BaseDataObject
    {
        public User Owner { get; set; }
        public string Manufacturer { get; set; }
        public string MobileOperator { get; set; }
        public bool IsJailbroken { get; set; }
        public string Version { get; set; }
        public string OS { get; set; }
        public long FreeSpace { get; set; }
    }
}
