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

        public RainbowProfile(byte[] data)
        {
            if (data.Length != 192)
            {
                throw new ArgumentException("data must be a 192 byte block");
            }
            if ((data[0] & (0b0111111)) != 3)
            {
                throw new ArgumentException("type identifier must be 3 for RainbowProfile type");
            }

            Speed = BitConverter.ToSingle(data, 1);
            Offset = BitConverter.ToSingle(data, 5);

            var nameUTF8 = new byte[32];
            Buffer.BlockCopy(data, 9, nameUTF8, 0, 32);
            Name = Encoding.UTF8.GetString(nameUTF8);
        }

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

        public override string ToString()
        {
            string ret = "";
            ret += $"Profile Type: Rainbow\n";
            ret += $"Name: {Name}\n";
            ret += $"Offset: {Offset}\n";
            ret += $"Speed: {Speed}\n";
            return ret;
        }
    }
}
