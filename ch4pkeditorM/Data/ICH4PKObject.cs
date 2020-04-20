using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch4pkeditorM.Data
{
    public interface ICH4PKObject
    {
        byte[] ToByte();
        bool IsExist();
    }
}
