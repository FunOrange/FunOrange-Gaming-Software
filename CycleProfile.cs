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

        public CycleProfile(string name)
        {
            Name = name;
            Colors = new List<Color>();
            ColorDuration = 0;
            Reverse = false;
        }

        public CycleProfile(byte[] data)
        {
            if (data.Length != 192)
            {
                throw new ArgumentException("data must be a 192 byte block");
            }
            if ((data[0] & (0b0111111)) != 2)
            {
                throw new ArgumentException("type identifier must be 2 for CycleProfile type");
            }

            int numColours = data[1];
            ColorDuration = BitConverter.ToInt16(data, 2);
            Reverse = (data[4] == 0) ? false : true;

            int ptr = 5;
            Colors = new List<Color>();
            for (int i = 0; i < numColours; i++)
            {
                byte r = data[ptr + 0];
                byte g = data[ptr + 1];
                byte b = data[ptr + 2];
                Colors.Add(Color.FromArgb(r, g, b));
                ptr += 3;
            }

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
        public override string ToString()
        {
            string ret = "";
            ret += $"Profile Type: Colour Cycle\n";
            ret += $"Name: {Name}\n";
            ret += $"ColorDuration: {ColorDuration}\n";
            ret += $"Reverse: {Reverse}\n";
            ret += $"Colors: {Colors.Count}\n";
            foreach (var color in Colors)
            {
                ret += color.ToString() + "\n";
            }
            return ret;
        }
    }
}
