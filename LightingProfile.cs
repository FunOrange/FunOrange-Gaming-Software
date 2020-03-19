using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunOrange_Gaming_Software
{
    abstract class LightingProfile
    {
        public string Name; // 32 byte C string
        public abstract byte[] Serialize();

        // convert a block of raw bytes representing profile data and convert it to a profile object
        public static LightingProfile Deserialize(byte[] data)
        {
            if (data.Length != 192)
            {
                throw new ArgumentException("Data must be a 192 byte block");
            }
            // clear MSB (represents whether a profile is active)
            int type = data[0] & 0b01111111;
            switch (type)
            {
                case 1:
                    return new ReactiveProfile(data);
                case 2:
                    return new CycleProfile(data);
                case 3:
                    return new RainbowProfile(data);
                default:
                    throw new Exception("WTF IS THIS");
            }
        }

        // Convert user-given name to utf8 encoded bytes
        protected byte[] NameToUTF8()
        {
            // pad with zeros
            byte[] ret = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                ret[i] = 0x0;
            }
            byte[] nameUTF8 = System.Text.Encoding.UTF8.GetBytes(Name);
            Buffer.BlockCopy(nameUTF8, 0, ret, 0, nameUTF8.Length);

            return ret;
        }
    }
}
