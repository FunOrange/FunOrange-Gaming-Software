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
        public List<Color> Colors;

        public ReactiveProfile(byte[] data)
        {
            if (data.Length != 192)
            {
                throw new ArgumentException("data must be a 192 byte block");
            }
            if ((data[0] & (0b0111111)) != 1)
            {
                throw new ArgumentException("type identifier must be 1 for ReactiveProfile type");
            }

            int numColoursLeft = data[1];
            int numColoursRight = data[2]; // ignore
            DecayDuration = BitConverter.ToInt16(data, 3);
            int ledMask = data[5]; // ignore

            // read left colour array
            int ptr = 6;
            Colors = new List<Color>();
            for (int i = 0; i < numColoursLeft; i++)
            {
                byte r = data[ptr + 0];
                byte g = data[ptr + 1];
                byte b = data[ptr + 2];
                Colors.Add(Color.FromArgb(r, g, b));
                ptr += 3;
            }
               
            // ignore right colour array 
            for (int i = 0; i < numColoursRight; i++)
            {
                //byte r = data[ptr + 0];
                //byte g = data[ptr + 1];
                //byte b = data[ptr + 2];
                //colors.Add(Color.FromArgb(r, g, b));
                ptr += 3;
            }

            // read name string
            var nameUTF8 = new byte[32];
            Buffer.BlockCopy(data, ptr, nameUTF8, 0, 32);
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
            ret[0] = 1;

            // num_colours_l [1] (1 byte int)
            ret[1] = (byte) Colors.Count;
            // num_colours_r [2] (1 byte int)
            ret[2] = 0;

            // decay_duration [3,4] (2 byte int)
            byte[] decayDuration = BitConverter.GetBytes(DecayDuration);
            Buffer.BlockCopy(decayDuration, 0, ret, 3, 2);

            // led mask 
            ret[5] = 0xff; // TODO: confirm that bit 1 = left

            // color (3 bytes per color)
            int j = 6;
            for (int x = 0; x < Colors.Count; x++)
            {
                ret[j + 0] = Colors[x].R;
                ret[j + 1] = Colors[x].G;
                ret[j + 2] = Colors[x].B;
                j += 3;
            }

            // Name [j : j+32]
            Buffer.BlockCopy(NameToUTF8(), 0, ret, j, 32);

            return ret;
        }
        public override string ToString()
        {
            string ret = "";
            ret += $"Profile Type: Reactive\n";
            ret += $"Name: {Name}\n";
            ret += $"DecayDuration: {DecayDuration}\n";
            ret += $"Colors: {Colors.Count}\n";
            foreach (var color in Colors)
            {
                ret += color.ToString() + "\n";
            }
            return ret;
        }
    }
}
