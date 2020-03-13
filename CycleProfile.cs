using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunOrange_Gaming_Software
{
    class CycleProfile : LightingProfile
    {
        public List<Color> Colors;
        public int ColorDuration;
        public bool Reverse;
        public override byte[] Serialize()
        {
            byte[] ret = new byte[192];
            for (int i = 0; i < 192; i++)
            {
                ret[i] = 0x0;
            }

            // Type [0]
            ret[0] = 2;

            // num_colours [1] (1 byte int)
            ret[1] = (byte) Colors.Count;

            // color duration [2,3] (2 byte int)
            byte[] decayDuration = BitConverter.GetBytes(ColorDuration);
            Buffer.BlockCopy(decayDuration, 0, ret, 2, 2);

            // reverse [4] (1 byte bool)
            ret[4] = (byte) (Reverse ? 1 : 0); // TODO: confirm that bit 1 = left

            // color [5 : ?] (3 bytes per color)
            int j = 5;
            for (int x = 0; x < Colors.Count; x++)
            {
                ret[j + 0] = Colors[x].R;
                ret[j + 1] = Colors[x].G;
                ret[j + 2] = Colors[x].B;
                j += 3;
            }

            // Name [j : j+32] (32 byte utf8 string)
            Buffer.BlockCopy(NameToUTF8(), 0, ret, j, 32);

            return ret;
        }
    }
}
