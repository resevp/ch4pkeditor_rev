using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public class Country
    {
        private byte[] _originByte { get; set; }
        public int Order { get; set; }
        public byte Biography { get; set; }
        public string Name { get; set; }

        public Country(byte[] countryByte, int index)
        {
            Order = index;
            _originByte = countryByte;

            Biography = countryByte[CountryMemoryData.BiographyOffset[0]];

            Name = Util.ParseString(
                countryByte,
                CountryMemoryData.NameOffset[0],
                CountryMemoryData.NameOffset[1]
            );
        }

        public bool IsExist()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
    public static class CountryMemoryData
    {
        public const int BlockStart = 0x5E8180;
        public const int BlockDataLength = 0x130;
        public const int MaxNumber = 51;

        public static readonly int[] BiographyOffset = { 0, 1 };
        public static readonly int[] NameOffset = { 1, 19 };
    }
}
