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
        private SerialPort keypadPort;
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
            Console.WriteLine("Trying " + port);
            Regex comRegex = new Regex(@"COM\d+$");
            if (comRegex.Matches(port).Count == 0)
            {
                Console.WriteLine("Port is not in the form COM<num>. You entered: " + port);
                return;
            }
            try
            {
                keypadPort = new SerialPort(port, 9600);
                keypadPort.Open();
                // Read signature to make sure we selected the keypad
                //Console.WriteLine("writing \"fun\"");
                keypadPort.WriteLine("fun");
                //Console.WriteLine("waiting for \"oragne\"");
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
            fakeEepromProfiles = new byte[5, 196];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 196; j++)
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
            Console.WriteLine("todo");
#else
            Console.WriteLine("todo");
#endif
        }
        public void SetDebounce(byte rising, byte falling, byte side)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method SetDebounce before connection is established");
#if KP
            Console.WriteLine("todo");
#else
            fakeEepromDebounceTimes[0] = rising;
            fakeEepromDebounceTimes[1] = falling;
            fakeEepromDebounceTimes[2] = side;
#endif
        }
        public byte[] ReadDebounce()
        {
            if (!connectionEstablished)
            {
                
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapLeftKey before connection is established");
            }
#if KP
            Console.WriteLine("todo");
            return new byte[0];
#else
            var ret = new byte[3];
            Array.Copy(fakeEepromDebounceTimes, ret, 3);
            return ret;
#endif
        }
        public void RemapLeftKey(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapLeftKey before connection is established");
#if KP
            Console.WriteLine("todo");
#else
            fakeEepromButtonMappings[0] = keyCode;
#endif
        }
        public void RemapRightKey(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapRightKey before connection is established");
#if KP
            Console.WriteLine("todo");
#else
            fakeEepromButtonMappings[1] = keyCode;
#endif
        }
        public void RemapSideButton(byte keyCode)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method RemapSideButton before connection is established");
#if KP
            Console.WriteLine("todo");
#else
            fakeEepromButtonMappings[2] = keyCode;
#endif
        }
        public byte[] ReadKeybinds()
        {
            if (!connectionEstablished)
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method ReadKeybinds before connection is established");
#if KP
            Console.WriteLine("todo");
            return new byte[] {5, 5, 40};
#else
            var ret = new byte[3];
            Array.Copy(fakeEepromButtonMappings, ret, 3);
            return ret;
#endif
        }
        public void ActivateProfile()
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method ActivateProfile before connection is established");
            Console.WriteLine("todo");
            return;
        }
        public int GetActiveProfile()
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method GetActiveProfile before connection is established");
            Console.WriteLine("todo");
            return 1;
        }
        public void ReadProfile(int whichProfile)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method ReadProfile before connection is established");
            Console.WriteLine("todo");
            return;
        }
        public void WriteProfile(int whichProfile)
        {
            if (!connectionEstablished) 
                throw new NoKeypadConnectedException("Error: Trying to call serial interface method WriteProfile before connection is established");
            Console.WriteLine("todo");
            return;
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
