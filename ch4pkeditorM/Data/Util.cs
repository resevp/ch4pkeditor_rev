using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public static class Util
    {
public static string ParseString(byte[] inputByteArray, int start, int end)
{
    List<byte> temp = new List<byte>();
    for (int i = start; i < end; i++)
    {
        if (i == start && IsEndByte(inputByteArray[i]))
        {
            return "";
        }
        if (IsEndByte(inputByteArray[i]))
        {
            break;
        }
        temp.Add(inputByteArray[i]);
    }
    UTF8Encoding encoder = new UTF8Encoding();

    // Old code
    //byte[] converted = Encoding.Convert(Encoding.GetEncoding("Big5"), Encoding.UTF8, temp.ToArray());

    // New code
    byte[] converted = Encoding.Convert(Encoding.GetEncoding(ch4pkeditorM.Core.TextEncoding), Encoding.UTF8, temp.ToArray());

    return encoder.GetString(converted);
}
        public static bool IsEndByte(byte b)
        {
            return b == 0x00 || b == 0x20;
        }

        public static ushort ToUShort(byte[] data, int skip, int take)
        {
            return BitConverter.ToUInt16(data.Skip(skip).Take(take).ToArray(), 0);
        }
    }
}
