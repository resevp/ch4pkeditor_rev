using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public class General: ICH4PKObject
    {
        private byte[] _originByte { get; set; }
        private ushort _birth { get; set; }
        private ushort _served { get; set; }
        private ushort _skills { get; set; }
        private byte _moved { get; set; }

        public int Order { get; set; }
        public ushort Biography { get; set; }
        public ushort Face { get; set; }
        public string Name { get; set; }
        public ushort StayCity { get; set; }
        public ushort XPos { get; set; }
        public ushort YPos { get; set; }
        public byte Pulitic { get; set; }
        public byte Attack { get; set; }
        public byte Intelligence { get; set; }
        public byte Loyalty { get; set; }
        public byte Exploit { get; set; }
        public byte Infantry { get; set; }
        public byte Archar { get; set; }
        public byte Cavalry { get; set; }
        public byte Navy { get; set; }
        public ushort Teacher { get; set; }

        public General(byte[] generalByte, int index){
            Order = index;
            _originByte = generalByte;

            Biography = Util.ToUShort(
                generalByte, 
                GeneralMemoryData.BiographyOffset[0], 
                GeneralMemoryData.BiographyOffset[1]
            );

            Face = Util.ToUShort(
                generalByte,
                GeneralMemoryData.FaceOffset[0],
                GeneralMemoryData.FaceOffset[1]
            );

            Name = Util.ParseString(
                generalByte, 
                GeneralMemoryData.NameOffset[0], 
                GeneralMemoryData.NameOffset[1]
            );

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            StayCity = Util.ToUShort(
                generalByte,
                GeneralMemoryData.StayCityOffset[0],
                GeneralMemoryData.StayCityOffset[1]
            );

            XPos = Util.ToUShort(
                generalByte,
                GeneralMemoryData.XPosOffset[0],
                GeneralMemoryData.XPosOffset[1]
            );

            YPos = Util.ToUShort(
                generalByte,
                GeneralMemoryData.YPosOffset[0],
                GeneralMemoryData.YPosOffset[1]
            );

            _birth = Util.ToUShort(
                generalByte,
                GeneralMemoryData.BirthOffset[0],
                GeneralMemoryData.BirthOffset[1]
            );

            _served = Util.ToUShort(
                generalByte,
                GeneralMemoryData.ServedOffset[0],
                GeneralMemoryData.ServedOffset[1]
            );

            Pulitic = generalByte[GeneralMemoryData.PuliticOffset[0]];

            Attack = generalByte[GeneralMemoryData.AttackOffset[0]];

            Intelligence = generalByte[GeneralMemoryData.IntelligenceOffset[0]];

            Loyalty = generalByte[GeneralMemoryData.LoyaltyOffset[0]];

            Exploit = generalByte[GeneralMemoryData.ExploitOffset[0]];

            Infantry = generalByte[GeneralMemoryData.InfantryOffset[0]];

            Archar = generalByte[GeneralMemoryData.ArcharOffset[0]];

            Cavalry = generalByte[GeneralMemoryData.CavalryOffset[0]];

            Navy = generalByte[GeneralMemoryData.NavyOffset[0]];

            _skills = Util.ToUShort(
                generalByte,
                GeneralMemoryData.SkillsOffset[0],
                GeneralMemoryData.SkillsOffset[1]
            );

            _moved = generalByte[GeneralMemoryData.MovedOffset[0]];

            Teacher = Util.ToUShort(
                generalByte,
                GeneralMemoryData.TeacherOffset[0],
                GeneralMemoryData.TeacherOffset[1]
            );
        }

        #region Skill Settings
        // 戰鬥特技
        public bool Ambush
        {
            get { return HasSkill(GeneralMemoryData.AmbushBit); }
            set { setSkill(GeneralMemoryData.AmbushBit, value); }
        }
        public bool Siege
        {
            get { return HasSkill(GeneralMemoryData.SiegeBit); }
            set { setSkill(GeneralMemoryData.SiegeBit, value); }
        }
        public bool FireAttack
        {
            get { return HasSkill(GeneralMemoryData.FireAttackBit); }
            set { setSkill(GeneralMemoryData.FireAttackBit, value); }
        }
        public bool RunningFire
        {
            get { return HasSkill(GeneralMemoryData.RunningFireBit); }
            set { setSkill(GeneralMemoryData.RunningFireBit, value); }
        }
        public bool Assault
        {
            get { return HasSkill(GeneralMemoryData.AssaultBit); }
            set { setSkill(GeneralMemoryData.AssaultBit, value); }
        }
        public bool Mobile
        {
            get { return HasSkill(GeneralMemoryData.MobileBit); }
            set { setSkill(GeneralMemoryData.MobileBit, value); }
        }
        // 內政特技
        public bool Hire
        {
            get { return HasSkill(GeneralMemoryData.HireBit); }
            set { setSkill(GeneralMemoryData.HireBit, value); }
        }
        public bool Diplomacy
        {
            get { return HasSkill(GeneralMemoryData.DiplomacyBit); }
            set { setSkill(GeneralMemoryData.DiplomacyBit, value); }
        }
        public bool Culture
        {
            get { return HasSkill(GeneralMemoryData.CultureBit); }
            set { setSkill(GeneralMemoryData.CultureBit, value); }
        }
        public bool Building
        {
            get { return HasSkill(GeneralMemoryData.BuildingBit); }
            set { setSkill(GeneralMemoryData.BuildingBit, value); }
        }
        public bool Business
        {
            get { return HasSkill(GeneralMemoryData.BusinessBit); }
            set { setSkill(GeneralMemoryData.BusinessBit, value); }
        }
        public bool Farm
        {
            get { return HasSkill(GeneralMemoryData.FarmBit); }
            set { setSkill(GeneralMemoryData.FarmBit, value); }
        }
        public bool HasSkill(ushort target)
        {
            return ((_skills & target) == target);
        }
        private void setSkill(ushort target, bool status)
        {
            int temp = _skills & target;
            bool curStatus = temp == target;
            if (curStatus == status)
            {
                return;
            }
            _skills = (ushort)(_skills ^ target);
        }
        #endregion
        #region Move Settings
        public bool IsMoved()
        {
            return ((_moved & GeneralMemoryData.MovedBit) == GeneralMemoryData.MovedBit);
        }
        public void SetMoved(bool moved)
        {
            int temp = _moved & GeneralMemoryData.MovedBit;
            bool curStatus = temp == GeneralMemoryData.MovedBit;
            if (curStatus == moved)
            {
                return;
            }
            _moved = (byte)(_moved ^ GeneralMemoryData.MovedBit);
        }
        #endregion
        #region Birth Settings
        public int GetBirth()
        {
            return _birth & GeneralMemoryData.BirthBit;
        }
        public void SetBirth(ushort birth)
        {
            if (birth > GeneralMemoryData.BirthBit)
            {
                // error
                return;
            }
            ushort birthByteClear = (ushort)(_birth & (ushort.MaxValue - GeneralMemoryData.BirthBit));
            _birth = (ushort)(birthByteClear | birth);
        }
        #endregion
        #region Served Settings
        public int GetServed()
        {
            return _served & GeneralMemoryData.ServedBit;
        }
        public void SetServed(ushort served)
        {
            if (served > GeneralMemoryData.ServedBit)
            {
                // error
                return;
            }
            ushort servedByteClear = (ushort)(_served & (ushort.MaxValue - GeneralMemoryData.ServedBit));
            _served = (ushort)(servedByteClear | served);
        }
        #endregion

        public bool IsExist()
        {
            return !string.IsNullOrEmpty(Name);
        }
        public byte[] ToByte()
        {
            byte[] rtnBytes = _originByte;
            byte[] temp = BitConverter.GetBytes(_birth);
            rtnBytes[GeneralMemoryData.BirthOffset[0]] = temp[0];
            rtnBytes[GeneralMemoryData.BirthOffset[0] + 1] = temp[1];
            temp = BitConverter.GetBytes(_served);
            rtnBytes[GeneralMemoryData.ServedOffset[0]] = temp[0];
            rtnBytes[GeneralMemoryData.ServedOffset[0] + 1] = temp[1];
            rtnBytes[GeneralMemoryData.PuliticOffset[0]] = Pulitic;
            rtnBytes[GeneralMemoryData.AttackOffset[0]] = Attack;
            rtnBytes[GeneralMemoryData.IntelligenceOffset[0]] = Intelligence;
            rtnBytes[GeneralMemoryData.LoyaltyOffset[0]] = Loyalty;
            rtnBytes[GeneralMemoryData.ExploitOffset[0]] = Exploit;
            rtnBytes[GeneralMemoryData.InfantryOffset[0]] = Infantry;
            rtnBytes[GeneralMemoryData.ArcharOffset[0]] = Archar;
            rtnBytes[GeneralMemoryData.CavalryOffset[0]] = Cavalry;
            rtnBytes[GeneralMemoryData.NavyOffset[0]] = Navy;
            temp = BitConverter.GetBytes(_skills);
            rtnBytes[GeneralMemoryData.SkillsOffset[0]] = temp[0];
            rtnBytes[GeneralMemoryData.SkillsOffset[0] + 1] = temp[1];
            rtnBytes[GeneralMemoryData.MovedOffset[0]] = _moved;
            temp = BitConverter.GetBytes(Teacher);
            rtnBytes[GeneralMemoryData.TeacherOffset[0]] = temp[0];
            rtnBytes[GeneralMemoryData.TeacherOffset[0] + 1] = temp[1];
            return rtnBytes;
        }
    }
    public static class GeneralMemoryData
    {
        public const int BlockStart = 0x5F415E;
        public const int BlockDataLength = 0x3C;
        public const ushort BirthBit = 0x7FF;
        public const ushort ServedBit = 0x7FF;
        public const byte MovedBit = 0x40;
        public const int MaxNumber = 500;

        // 戰鬥特技
        public const ushort AmbushBit = 0x800;
        public const ushort SiegeBit = 0x400;
        public const ushort FireAttackBit = 0x200;
        public const ushort RunningFireBit = 0x100;
        public const ushort AssaultBit = 0x80;
        public const ushort MobileBit = 0x40;

        // 內政特技
        public const ushort HireBit = 0x20;
        public const ushort DiplomacyBit = 0x10;
        public const ushort CultureBit = 0x8;
        public const ushort BuildingBit = 0x4;
        public const ushort BusinessBit = 0x2;
        public const ushort FarmBit = 0x1;

        public static readonly int[] BiographyOffset = { 0, 2 };
        public static readonly int[] FaceOffset = { 2, 2 };
        public static readonly int[] NameOffset = { 4, 18 };
        public static readonly int[] StayCityOffset = { 22, 2 };
        public static readonly int[] XPosOffset = { 26, 2 };
        public static readonly int[] YPosOffset = { 28, 2 };
        public static readonly int[] BirthOffset = { 38, 2 };
        public static readonly int[] ServedOffset = { 40, 2 };
        public static readonly int[] PuliticOffset = { 42, 1 };
        public static readonly int[] AttackOffset = { 43, 1 };
        public static readonly int[] IntelligenceOffset = { 44, 1 };
        public static readonly int[] LoyaltyOffset = { 45, 1 };
        public static readonly int[] ExploitOffset = { 46, 1 };
        public static readonly int[] InfantryOffset = { 47, 1 };
        public static readonly int[] ArcharOffset = { 48, 1 };
        public static readonly int[] CavalryOffset = { 49, 1 };
        public static readonly int[] NavyOffset = { 50, 1 };
        public static readonly int[] SkillsOffset = { 52, 2 };
        public static readonly int[] MovedOffset = { 57, 1 };
        public static readonly int[] TeacherOffset = { 58, 2 };
    }

    public static class GeneralDataValidation
    {
        public enum Normal: ushort {
            MIN = 0,
            MAX = 100
        };
        public enum Arms: ushort
        {
            MIN = 0,
            MAX = 5
        };
    }
}
