using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public class Wife: ICH4PKObject
    {
        private byte[] _originByte { get; set; }
        private ushort _married { get; set; }
        private byte _pregnent { get; set; }

        public int Order { get; set; }
        public byte DefaultFace { get; set; }
        public byte Face { get; set; }
        public string Name { get; set; }
        public ushort Husband { get; set; }
        public byte Pregnent { get; set; }

        public Wife(byte[] wifeByte, int index)
        {
            Order = index;
            _originByte = wifeByte;

            DefaultFace = wifeByte[WifeMemoryData.DefaultFaceOffset[0]];

            Face = wifeByte[WifeMemoryData.FaceOffset[0]];

            Name = Util.ParseString(
                wifeByte,
                WifeMemoryData.NameOffset[0],
                WifeMemoryData.NameOffset[1]
            );

            Husband = Util.ToUShort(
                wifeByte,
                WifeMemoryData.HusbandOffset[0],
                WifeMemoryData.HusbandOffset[1]
            );

            Pregnent = wifeByte[WifeMemoryData.PregnentOffset[0]];

            _married = Util.ToUShort(
                wifeByte,
                WifeMemoryData.MarriedYearOffset[0],
                WifeMemoryData.MarriedYearOffset[1]
            );
        }

        #region Married Settings
        public int GetMarried()
        {
            return _married & WifeMemoryData.MarriedBit;
        }
        public void SetMarried(ushort married)
        {
            if(married > WifeMemoryData.MarriedBit)
            {
                return;
            }
            ushort marriedByteClear = (ushort)(_married & (ushort.MaxValue - WifeMemoryData.MarriedBit));
            _married = (ushort)(marriedByteClear | married);
        }
        #endregion

        public bool IsPregnent()
        {
            return Pregnent != WifeMemoryData.NoPregnent;
        }
        public bool IsBoyBaby()
        {
            return WifeMemoryData.BoyBaby.Contains(Pregnent);
        }
        public bool IsGirlBaby()
        {
            return WifeMemoryData.GirlBaby.Contains(Pregnent);
        }
        public bool IsInPregnentPeriod(int index)
        {
            return (
                Pregnent == WifeMemoryData.BoyBaby.ElementAt(index) || 
                Pregnent == WifeMemoryData.GirlBaby.ElementAt(index)
            );
        }

        public bool IsExist()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public byte[] ToByte()
        {
            byte[] rtnBytes = _originByte;
            byte[] temp = BitConverter.GetBytes(Husband);
            rtnBytes[WifeMemoryData.HusbandOffset[0]] = temp[0];
            rtnBytes[WifeMemoryData.HusbandOffset[0] + 1] = temp[1];
            rtnBytes[WifeMemoryData.PregnentOffset[0]] = Pregnent;
            return rtnBytes;
        }
    }
    public static class WifeMemoryData
    {
        public const int BlockStart = 0x5FB6CA;
        public const int BlockDataLength = 0x1C;
        public const int MaxNumber = 200;
        public const int MarriedBit = 0x7FF;

        public const byte NoPregnent = 0x2;
        public static readonly byte[] BoyBaby = { 0x36, 0x32, 0x2E, 0x2A, 0x26 };
        public static readonly byte[] GirlBaby = { 0x56, 0x52, 0x4E, 0x4A, 0x46 };

        public static byte GetPregnentByte(bool isGirl, int selectedPeriod)
        {
            return isGirl ? GirlBaby.ElementAt(selectedPeriod) : BoyBaby.ElementAt(selectedPeriod);
        }

        public static readonly int[] DefaultFaceOffset = { 0, 1 };
        public static readonly int[] FaceOffset = { 1, 1 };
        public static readonly int[] NameOffset = { 2, 17 };
        public static readonly int[] HusbandOffset = { 20, 2 };
        public static readonly int[] PregnentOffset = { 25, 1 };
        public static readonly int[] MarriedYearOffset = { 26, 2 };
    }
}
