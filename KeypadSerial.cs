#undef KP // this means "I have a physical keypad to use this software with"
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace FunOrange_Gaming_Software
{
    class KeypadSerial
    {

        // state variables
#if KP
        private SerialPort keypadPort;
#endif
        private bool connectionEstablished;

        // simulated eeprom
#if !KP
        private byte[,] fakeEepromProfiles;
        private byte[] fakeEepromButtonMappings;
        private byte[] fakeEepromDebounceTimes;
#endif
        public KeypadSerial()
        {
            connectionEstablished = false;
            if (Program.DEBUG) Console.WriteLine("Entered SerialInterface constructor");
        }

        public void ConnectToKeypad(string port)
        {
#if KP
            Regex comRegex = new Regex(@"COM\d+$");
            if (comRegex.Matches(port).Count == 0)
            {
                Console.WriteLine("Port is not in the form COM<num>. You entered: " + port);
                return;
            }
            try
            {
                Disconnect();
                keypadPort = new SerialPort(port, 9600);
                keypadPort.Open();
                // Read signature to make sure we selected the keypad
                if (Program.DEBUG) Console.WriteLine("writing \"fun\"");
                keypadPort.WriteLine("fun");
                if (Program.DEBUG) Console.WriteLine("waiting for \"orange\"");
                if (keypadPort.ReadLine() == "orange")
                {
                    Console.WriteLine("Connection with keypad successfully established!");
                    connectionEstablished = true;
                }
                else
                {
                    Console.WriteLine("Serial port did not respond with keypad signature");
                    connectionEstablished = false;
                }
            } catch (System.IO.IOException) {
                Console.WriteLine("Connection with keypad successfully failed!");
                Environment.Exit(-1);
            }
#else
            Console.WriteLine("No keypad. Serial interface methods will return fake values, mimicking the response of a real keypad.");

            // simulate eeprom here; fill with factory default values
            // profiles
            fakeEepromProfiles = new byte[5, 192];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 192; j++)
                {
                    fakeEepromProfiles[i, j] = 0xff;
                }
            }
            // keymap and debounce
            fakeEepromButtonMappings = new byte[] { 90, 88, 67 };
            fakeEepromDebounceTimes = new byte[] { 2, 10, 30 };

            connectionEstablished = true;
#endif
        }

        public void Disconnect()
        {
#if KP
            if (keypadPort != null && keypadPort.IsOpen)
            {
                keypadPort.Close();
            }
#endif
            connectionEstablished = false;
        }

        public void EraseEEPROM()
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method EraseEEPROM before connection is established."); ;
#if KP
            keypadPort.WriteLine("erase");
            Ack();
#else
            fakeEepromProfiles = new byte[5, 192];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 192; j++)
                {
                    fakeEepromProfiles[i, j] = 0xff;
                }
            }
            // keymap and debounce
            fakeEepromButtonMappings = new byte[] { 0xff, 0xff, 0xff };
            fakeEepromDebounceTimes = new byte[] { 0xff, 0xff, 0xff };
#endif
        }

        public void SetDebounce(byte rising, byte falling, byte side)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method SetDebounce before connection is established");
#if KP
            keypadPort.WriteLine("set debounce");
            Ack();
            keypadPort.Write(new byte[] {rising, falling, side}, 0, 3);
            Ack();
#else
            fakeEepromDebounceTimes[0] = rising;
            fakeEepromDebounceTimes[1] = falling;
            fakeEepromDebounceTimes[2] = side;
#endif
            Console.WriteLine("Set Debounce Success");
        }

        public byte[] ReadDebounce()
        {
            if (!connectionEstablished)
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapLeftKey before connection is established");
            var ret = new byte[3];
#if KP
            keypadPort.WriteLine("read debounce");
            Ack();
            keypadPort.Read(ret, 0, 3);
#else
            Array.Copy(fakeEepromDebounceTimes, ret, 3);
#endif
            return ret;
        }

        public void RemapLeftKey(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapLeftKey before connection is established");
#if KP
            // read, modify, write
            byte[] old = ReadKeybinds();
            keypadPort.WriteLine("remap keys");
            Ack();
            keypadPort.Write(new byte[] { keyCode, old[1], old[2] }, 0, 3);
            Ack();
#else
            fakeEepromButtonMappings[0] = keyCode;
#endif
        }

        public void RemapRightKey(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapRightKey before connection is established");
#if KP
            // read, modify, write
            byte[] old = ReadKeybinds();
            keypadPort.WriteLine("remap keys");
            Ack();
            keypadPort.Write(new byte[] { old[0], keyCode, old[2] }, 0, 3);
            Ack();
#else
            fakeEepromButtonMappings[1] = keyCode;
#endif
        }

        public void RemapSideButton(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapSideButton before connection is established");
#if KP
            // read, modify, write
            byte[] old = ReadKeybinds();
            keypadPort.WriteLine("remap keys");
            Ack();
            keypadPort.Write(new byte[] { old[0], old[1], keyCode }, 0, 3);
            Ack();
#else
            fakeEepromButtonMappings[2] = keyCode;
#endif
        }

        public byte[] ReadKeybinds()
        {
            if (!connectionEstablished)
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method ReadKeybinds before connection is established");

            var ret = new byte[3];
#if KP
            keypadPort.WriteLine("read keybinds");
            Ack();
            keypadPort.Read(ret, 0, 3);
#else
            Array.Copy(fakeEepromButtonMappings, ret, 3);
#endif
            return ret;
        }

        // Returns the profile which is currently running on the keypad.
        // Returns -1 if no profile is currently active
        public int GetActiveProfile()
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method GetActiveProfile before connection is established");

#if KP
            keypadPort.WriteLine("which active");
            Ack();
            string response = keypadPort.ReadLine();
            return int.Parse(response);
#else
            for (int i = 0; i < 5; i++)
            {
                if ((fakeEepromProfiles[i,0] & 0b10000000) != 0)
                {
                    return i + 1;
                }
            }
            return -1; // no active profile
#endif
        }
        public void SetActiveProfile(int whichProfile)
        {
#if KP
            keypadPort.WriteLine("select profile");
            Ack();
            keypadPort.WriteLine(whichProfile.ToString());
            Ack();
#else
            // disable all profiles (clear bit 8 of byte 0)
            for (int i = 0; i < 5; i++)
            {
                fakeEepromProfiles[i, 0] = (byte)(fakeEepromProfiles[i, 0] & 0b01111111);
            }

            // enable the profile (set bit 8 of byte 0)
            fakeEepromProfiles[whichProfile-1, 0] = (byte) (fakeEepromProfiles[whichProfile-1, 0] | 0b10000000);
#endif
        }

        public LightingProfile ReadProfile(int whichProfile)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method ReadProfile before connection is established");
            if ((whichProfile >= 1 && whichProfile <= 5) == false)
            {
                throw new ArgumentException("Profile must be in range [1,5]");
            }
#if KP
            keypadPort.WriteLine("read profile");
            Ack();
            keypadPort.WriteLine(whichProfile.ToString());
            Ack();
            var profileData = new byte[192];
            keypadPort.Read(profileData, 0, 192);
            return LightingProfile.Deserialize(profileData);
#else
            byte[] profileData = new byte[192];
            int row = whichProfile - 1; // -1 because 0 indexed
            Buffer.BlockCopy(fakeEepromProfiles, row * 192, profileData, 0, 192);
            return LightingProfile.Deserialize(profileData); // -1 because 0 indexed
#endif
        }

        public void WriteProfile(int whichProfile, LightingProfile profile)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method WriteProfile before connection is established");
            if ((whichProfile >= 1 && whichProfile <= 5) == false)
            {
                throw new ArgumentException("Profile must be in range [1,5]");
            }
            if (profile == null)
            {
                throw new ArgumentException("Cannot write a null profile.");
            }
#if KP
            keypadPort.WriteLine("write profile");
            Ack();
            keypadPort.WriteLine(whichProfile.ToString());
            Ack();
            keypadPort.Write(profile.Serialize(), 0, 192);
            Ack();
#else
            var profileData = profile.Serialize();
            int row = whichProfile - 1; // -1 because 0 indexed
            Buffer.BlockCopy(profileData, 0, fakeEepromProfiles, row * 192, 192);
#endif
        }

        public void ShowPorts()
        {
            using (var searcher = new ManagementObjectSearcher
                            ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();

                tList.ForEach(Console.WriteLine);
            }
        }

#if KP
        private bool Ack()
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method Ack() before connection is established");
            // What do we do if timeout happens?
            if (Program.DEBUG) Console.Write("Ack... ");
            bool success = keypadPort.ReadLine() == "ack";
            if (Program.DEBUG) Console.WriteLine(success);
            return success;
        }
#endif
    }

    [Serializable]
    public class NoKeypadConnectedException : Exception
    {
        public NoKeypadConnectedException() { }
        public NoKeypadConnectedException(string message) : base(message) { }
        public NoKeypadConnectedException(string message, Exception inner) : base(message, inner) { }
        protected NoKeypadConnectedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
