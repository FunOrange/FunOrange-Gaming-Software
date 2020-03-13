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
