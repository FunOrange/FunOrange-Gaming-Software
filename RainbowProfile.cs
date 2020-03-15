using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunOrange_Gaming_Software
{
    class RainbowProfile : LightingProfile
    {
        public float Speed; // How fast to rotate around colour wheel
        public float Offset; // colour degree offset between adjacent LEDs

        public override byte[] Serialize()
        {
            byte[] ret = new byte[192];
            for (int i = 0; i < 192; i++)
            {
                ret[i] = 0x0;
            }

            // Type [0]
            ret[0] = 3;

            // Speed [1,2,3,4] (4 byte float)
            byte[] speed = BitConverter.GetBytes(Speed);
            Buffer.BlockCopy(speed, 0, ret, 1, 4);

            // Offset [5,6,7,8] (4 byte float)
            byte[] offset = BitConverter.GetBytes(Offset);
            Buffer.BlockCopy(offset, 0, ret, 5, 4);

            // Name [9 : 9+32] (32 byte utf8 string)
            Buffer.BlockCopy(NameToUTF8(), 0, ret, 9, 32);

            return ret;
        }
}
}
