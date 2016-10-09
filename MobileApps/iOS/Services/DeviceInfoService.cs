using CoreTelephony;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace BeerDrinkin.iOS.Services
{
    public class DeviceInfoService
    {
        public static Models.DeviceInfo CurrentDevice
        {
            get
            {
                return new Models.DeviceInfo
                {
                    Manufacturer = "Apple",
                    IsJailbroken = GetIsJailBroken(),
                    Version = GetOSVersion(),
                    MobileOperator = GetCarrierName(),
                    FreeSpace = GetFreeSpace()
                };
            }
        }

        static bool GetIsJailBroken()
        {
            bool deviceIsJailbroken = false;
            string[] knownSmokingGuns =
            {
                "/Applications/Cydia.app",
                "/Library/MobileSubstrate/MobileSubstrate.dylib",
                "/var/cache/apt",
                "/var/lib/apt",
                "/var/lib/cydia",
                "/var/log/syslog",
                "/var/tmp/cydia.log",
                "/bin/bash",
                "/bin/sh",
                "/usr/sbin/sshd",
                "/usr/libexec/ssh-keysign",
                "/etc/ssh/sshd_config",
                "/etc/apt"
            };

            foreach(var item in knownSmokingGuns)
            {
                deviceIsJailbroken = NSFileManager.DefaultManager.FileExists(item);
                if (deviceIsJailbroken)
                    break;
            }
            return deviceIsJailbroken;            
        }

        static string GetOSVersion()
        {
            return UIDevice.CurrentDevice.SystemVersion; 
        }

        static string GetCarrierName()
        {
            using (var info = new CTTelephonyNetworkInfo())
            {
                return info.SubscriberCellularProvider.CarrierName;
            }
        }

        static long GetFreeSpace()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            NSDictionary dictionary = NSFileManager.DefaultManager.GetFileSystemAttributes(path);
            var number = (NSNumber)dictionary.ObjectForKey(NSObject.FromObject(NSFileManager.SystemFreeSize));
            var freeBytes = number.UInt64Value;

            return (long)freeBytes;
        }
    }
}
