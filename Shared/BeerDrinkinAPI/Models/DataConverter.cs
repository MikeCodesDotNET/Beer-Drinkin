using System;

namespace BeerDrinkin.Models
{
    public static class DataConverter
    {
        public static byte[] GetDataFromString(string imageData)
        {
            return Convert.FromBase64String(imageData);
        }

        public static string GetStringFromData(byte[] data)
        {
            return Convert.ToBase64String(data);
        }
    }
}