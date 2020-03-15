using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunOrange_Gaming_Software
{
    class ReactiveProfile : LightingProfile
    {
        public int DecayDuration;
        public List<Color> colors;

        public override byte[] Serialize()
        {
            byte[] ret = new byte[192];
            for (int i = 0; i < 192; i++)
            {
                ret[i] = 0x0;
            }

            // Type [0]
            ret[0] = 1;

            // num_colours_l [1] (1 byte int)
            ret[1] = (byte) colors.Count;
            // num_colours_r [2] (1 byte int)
            ret[2] = 0;

            // decay_duration [3,4] (2 byte int)
            byte[] decayDuration = BitConverter.GetBytes(DecayDuration);
            Buffer.BlockCopy(decayDuration, 0, ret, 3, 2);

            // led mask 
            ret[5] = 0xff; // TODO: confirm that bit 1 = left

            // color (3 bytes per color)
            int j = 6;
            for (int x = 0; x < colors.Count; x++)
            {
                ret[j + 0] = colors[x].R;
                ret[j + 1] = colors[x].G;
                ret[j + 2] = colors[x].B;
                j += 3;
            }

            // Name [j : j+32]
            Buffer.BlockCopy(NameToUTF8(), 0, ret, j, 32);

            return ret;
        }
    }
}
