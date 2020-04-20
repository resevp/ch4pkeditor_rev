using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public class City: ICH4PKObject
    {
        private byte[] _originByte { get; set; }

        public int Order { get; set; }
        public byte Biography { get; set; }
        public string Name { get; set; }
        public byte Country { get; set; }
        public byte Scale { get; set; }
        public ushort Defence { get; set; }
        public ushort Money { get; set; }
        public ushort Food { get; set; }
        public ushort Army { get; set; }
        public byte Wine { get; set; }
        public byte OliveOil { get; set; }
        public byte Sugar { get; set; }
        public byte Tea { get; set; }
        public byte Seasoning { get; set; }
        public byte Horse { get; set; }
        public byte Elephant { get; set; }
        public byte Camel { get; set; }
        public byte Salt { get; set; }
        public byte Fur { get; set; }
        public byte SilkFabric { get; set; }
        public byte Wool { get; set; }
        public byte CottonFabric { get; set; }
        public byte Celadon { get; set; }
        public byte Pottery { get; set; }
        public byte Silverware { get; set; }
        public byte Glassware { get; set; }
        public byte Copper { get; set; }
        public byte Silver { get; set; }
        public byte Gold { get; set; }
        public byte Spices { get; set; }
        public byte Draw { get; set; }
        public byte TurtleShell { get; set; }
        public byte Amber { get; set; }
        public byte Coral { get; set; }
        public byte Emerald { get; set; }
        public byte Pearl { get; set; }
        public byte Ivory { get; set; }
        public byte Wood { get; set; }
        public byte ChineseMedicine { get; set; }
        public byte Iron { get; set; }

        public byte Farm { get; set; }
        public byte Husbandry { get; set; }
        public byte Weapon { get; set; }
        public byte Tactics { get; set; }
        public byte Sailing { get; set; }
        public byte Building { get; set; }
        public byte Academic { get; set; }
        public byte Art { get; set; }
        public byte Medical { get; set; }
        public byte Craft { get; set; }

        public City(byte[] cityByte, int index)
        {
            Order = index;
            _originByte = cityByte;

            Biography = cityByte[CityMemoryData.BiographyOffset[0]];

            Name = Util.ParseString(
                cityByte,
                CityMemoryData.NameOffset[0],
                CityMemoryData.NameOffset[1]
            );

            Country = cityByte[CityMemoryData.CountryOffset[0]];

            Scale = cityByte[CityMemoryData.ScaleOffset[0]];

            Defence = Util.ToUShort(
                cityByte,
                CityMemoryData.DefenceOffset[0],
                CityMemoryData.DefenceOffset[1]
            );

            Money = Util.ToUShort(
                cityByte,
                CityMemoryData.MoneyOffset[0],
                CityMemoryData.MoneyOffset[1]
            );

            Food = Util.ToUShort(
                cityByte,
                CityMemoryData.FoodOffset[0],
                CityMemoryData.FoodOffset[1]
            );

            Army = Util.ToUShort(
                cityByte,
                CityMemoryData.ArmyOffset[0],
                CityMemoryData.ArmyOffset[1]
            );

            // 特產品
            Wine = cityByte[CityMemoryData.WineOffset[0]];

            OliveOil = cityByte[CityMemoryData.OliveOilOffset[0]];

            Sugar = cityByte[CityMemoryData.SugarOffset[0]];

            Tea = cityByte[CityMemoryData.TeaOffset[0]];

            Seasoning = cityByte[CityMemoryData.SeasoningOffset[0]];

            Horse = cityByte[CityMemoryData.HorseOffset[0]];

            Elephant = cityByte[CityMemoryData.ElephantOffset[0]];

            Camel = cityByte[CityMemoryData.CamelOffset[0]];

            Salt = cityByte[CityMemoryData.SaltOffset[0]];

            Fur = cityByte[CityMemoryData.FurOffset[0]];

            SilkFabric = cityByte[CityMemoryData.SilkFabricOffset[0]];

            Wool = cityByte[CityMemoryData.WoolOffset[0]];

            CottonFabric = cityByte[CityMemoryData.CottonFabricOffset[0]];

            Celadon = cityByte[CityMemoryData.CeladonOffset[0]];

            Pottery = cityByte[CityMemoryData.PotteryOffset[0]];

            Silverware = cityByte[CityMemoryData.SilverwareOffset[0]];

            Glassware = cityByte[CityMemoryData.GlasswareOffset[0]];

            Copper = cityByte[CityMemoryData.CopperOffset[0]];

            Silver = cityByte[CityMemoryData.SilverOffset[0]];

            Gold = cityByte[CityMemoryData.GoldOffset[0]];

            Spices = cityByte[CityMemoryData.SpicesOffset[0]];

            Draw = cityByte[CityMemoryData.DrawOffset[0]];

            TurtleShell = cityByte[CityMemoryData.TurtleShellOffset[0]];

            Amber = cityByte[CityMemoryData.AmberOffset[0]];

            Coral = cityByte[CityMemoryData.CoralOffset[0]];

            Emerald = cityByte[CityMemoryData.EmeraldOffset[0]];

            Pearl = cityByte[CityMemoryData.PearlOffset[0]];

            Ivory = cityByte[CityMemoryData.IvoryOffset[0]];

            Wood = cityByte[CityMemoryData.WoodOffset[0]];

            ChineseMedicine = cityByte[CityMemoryData.ChineseMedicineOffset[0]];

            Iron = cityByte[CityMemoryData.IronOffset[0]];

            // 文化
            Farm = cityByte[CityMemoryData.FarmOffset[0]];

            Husbandry = cityByte[CityMemoryData.HusbandryOffset[0]];

            Weapon = cityByte[CityMemoryData.WeaponOffset[0]];

            Tactics = cityByte[CityMemoryData.TacticsOffset[0]];

            Sailing = cityByte[CityMemoryData.SailingOffset[0]];

            Building = cityByte[CityMemoryData.BuildingOffset[0]];

            Academic = cityByte[CityMemoryData.AcademicOffset[0]];

            Art = cityByte[CityMemoryData.ArtOffset[0]];

            Medical = cityByte[CityMemoryData.MedicalOffset[0]];

            Craft = cityByte[CityMemoryData.CraftOffset[0]];
        }

        public bool IsExist()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public byte[] ToByte()
        {
            byte[] rtnBytes = _originByte;
            rtnBytes[CityMemoryData.ScaleOffset[0]] = Scale;
            byte[] temp = BitConverter.GetBytes(Defence);
            rtnBytes[CityMemoryData.DefenceOffset[0]] = temp[0];
            rtnBytes[CityMemoryData.DefenceOffset[0] + 1] = temp[1];
            temp = BitConverter.GetBytes(Money);
            rtnBytes[CityMemoryData.MoneyOffset[0]] = temp[0];
            rtnBytes[CityMemoryData.MoneyOffset[0] + 1] = temp[1];
            temp = BitConverter.GetBytes(Food);
            rtnBytes[CityMemoryData.FoodOffset[0]] = temp[0];
            rtnBytes[CityMemoryData.FoodOffset[0] + 1] = temp[1];
            temp = BitConverter.GetBytes(Army);
            rtnBytes[CityMemoryData.ArmyOffset[0]] = temp[0];
            rtnBytes[CityMemoryData.ArmyOffset[0] + 1] = temp[1];
            rtnBytes[CityMemoryData.WineOffset[0]] = Wine;
            rtnBytes[CityMemoryData.OliveOilOffset[0]] = OliveOil;
            rtnBytes[CityMemoryData.SugarOffset[0]] = Sugar;
            rtnBytes[CityMemoryData.TeaOffset[0]] = Tea;
            rtnBytes[CityMemoryData.SeasoningOffset[0]] = Seasoning;
            rtnBytes[CityMemoryData.HorseOffset[0]] = Horse;
            rtnBytes[CityMemoryData.ElephantOffset[0]] = Elephant;
            rtnBytes[CityMemoryData.CamelOffset[0]] = Camel;
            rtnBytes[CityMemoryData.SaltOffset[0]] = Salt;
            rtnBytes[CityMemoryData.FurOffset[0]] = Fur;
            rtnBytes[CityMemoryData.SilkFabricOffset[0]] = SilkFabric;
            rtnBytes[CityMemoryData.WoolOffset[0]] = Wool;
            rtnBytes[CityMemoryData.CottonFabricOffset[0]] = CottonFabric;
            rtnBytes[CityMemoryData.CeladonOffset[0]] = Celadon;
            rtnBytes[CityMemoryData.PotteryOffset[0]] = Pottery;
            rtnBytes[CityMemoryData.SilverwareOffset[0]] = Silverware;
            rtnBytes[CityMemoryData.GlasswareOffset[0]] = Glassware;
            rtnBytes[CityMemoryData.CopperOffset[0]] = Copper;
            rtnBytes[CityMemoryData.SilverOffset[0]] = Silver;
            rtnBytes[CityMemoryData.GoldOffset[0]] = Gold;
            rtnBytes[CityMemoryData.SpicesOffset[0]] = Spices;
            rtnBytes[CityMemoryData.DrawOffset[0]] = Draw;
            rtnBytes[CityMemoryData.TurtleShellOffset[0]] = TurtleShell;
            rtnBytes[CityMemoryData.AmberOffset[0]] = Amber;
            rtnBytes[CityMemoryData.CoralOffset[0]] = Coral;
            rtnBytes[CityMemoryData.EmeraldOffset[0]] = Emerald;
            rtnBytes[CityMemoryData.PearlOffset[0]] = Pearl;
            rtnBytes[CityMemoryData.IvoryOffset[0]] = Ivory;
            rtnBytes[CityMemoryData.WoodOffset[0]] = Wood;
            rtnBytes[CityMemoryData.ChineseMedicineOffset[0]] = ChineseMedicine;
            rtnBytes[CityMemoryData.IronOffset[0]] = Iron;
            rtnBytes[CityMemoryData.FarmOffset[0]] = Farm;
            rtnBytes[CityMemoryData.HusbandryOffset[0]] = Husbandry;
            rtnBytes[CityMemoryData.WeaponOffset[0]] = Weapon;
            rtnBytes[CityMemoryData.TacticsOffset[0]] = Tactics;
            rtnBytes[CityMemoryData.SailingOffset[0]] = Sailing;
            rtnBytes[CityMemoryData.BuildingOffset[0]] = Building;
            rtnBytes[CityMemoryData.AcademicOffset[0]] = Academic;
            rtnBytes[CityMemoryData.ArtOffset[0]] = Art;
            rtnBytes[CityMemoryData.MedicalOffset[0]] = Medical;
            rtnBytes[CityMemoryData.CraftOffset[0]] = Craft;
            return rtnBytes; 
        }
    }
    public static class CityMemoryData
    {
        public const int BlockStart = 0x5EE1B0;
        public const int BlockDataLength = 0xC8;
        public const int MaxNumber = 80;
        // 特產品
        public static readonly int[] BiographyOffset = { 0, 1 };
        public static readonly int[] NameOffset = { 1, 21 };
        public static readonly int[] CountryOffset = { 22, 1 };
        public static readonly int[] ScaleOffset = { 23, 1 };
        public static readonly int[] DefenceOffset = { 24, 2 };
        public static readonly int[] MoneyOffset = { 26, 2 };
        public static readonly int[] FoodOffset = { 28, 2 };
        public static readonly int[] ArmyOffset = { 30, 2 };
        public static readonly int[] WineOffset = { 34, 1 };
        public static readonly int[] OliveOilOffset = { 35, 1 };
        public static readonly int[] SugarOffset = { 36, 1 };
        public static readonly int[] TeaOffset = { 37, 1 };
        public static readonly int[] SeasoningOffset = { 38, 1 };
        public static readonly int[] HorseOffset = { 39, 1 };
        public static readonly int[] ElephantOffset = { 40, 1 };
        public static readonly int[] CamelOffset = { 41, 1 };
        public static readonly int[] SaltOffset = { 42, 1 };
        public static readonly int[] FurOffset = { 43, 1 };
        public static readonly int[] SilkFabricOffset = { 44, 1 };
        public static readonly int[] WoolOffset = { 45, 1 };
        public static readonly int[] CottonFabricOffset = { 46, 1 };
        public static readonly int[] CeladonOffset = { 47, 1 };
        public static readonly int[] PotteryOffset = { 48, 1 };
        public static readonly int[] SilverwareOffset = { 49, 1 };
        public static readonly int[] GlasswareOffset = { 50, 1 };
        public static readonly int[] CopperOffset = { 51, 1 };
        public static readonly int[] SilverOffset = { 52, 1 };
        public static readonly int[] GoldOffset = { 53, 1 };
        public static readonly int[] SpicesOffset = { 54, 1 };
        public static readonly int[] DrawOffset = { 55, 1 };
        public static readonly int[] TurtleShellOffset = { 56, 1 };
        public static readonly int[] AmberOffset = { 57, 1 };
        public static readonly int[] CoralOffset = { 58, 1 };
        public static readonly int[] EmeraldOffset = { 59, 1 };
        public static readonly int[] PearlOffset = { 60, 1 };
        public static readonly int[] IvoryOffset = { 61, 1 };
        public static readonly int[] WoodOffset = { 62, 1 };
        public static readonly int[] ChineseMedicineOffset = { 63, 1 };
        public static readonly int[] IronOffset = { 64, 1 };
        // 文化
        public static readonly int[] FarmOffset = { 101, 1 };
        public static readonly int[] HusbandryOffset = { 102, 1 };
        public static readonly int[] WeaponOffset = { 103, 1 };
        public static readonly int[] TacticsOffset = { 104, 1 };
        public static readonly int[] SailingOffset = { 105, 1 };
        public static readonly int[] BuildingOffset = { 106, 1 };
        public static readonly int[] AcademicOffset = { 107, 1 };
        public static readonly int[] ArtOffset = { 108, 1 };
        public static readonly int[] MedicalOffset = { 109, 1 };
        public static readonly int[] CraftOffset = { 110, 1 };
    }

    public static class CityDataValidation
    {
        public enum Normal : ushort
        {
            MIN = 0,
            MAX = 50000
        };
        public enum Defence : ushort
        {
            MIN = 0,
            MAX = 800
        };
        public enum Scale: ushort
        {
            MIN = 0,
            MAX = 8
        };
        public enum Culture : ushort
        {
            MIN = 0,
            MAX = 200
        };
        public enum Specialty : ushort
        {
            MIN = 0,
            MAX = 200
        };
    }
}
