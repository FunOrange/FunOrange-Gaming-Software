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
        private byte[,] fakeEepromProfiles;
        private byte[] fakeEepromButtonMappings;
        private byte[] fakeEepromDebounceTimes;

        public KeypadSerial()
        {
            connectionEstablished = false;
            if (Program.DEBUG) Console.WriteLine("Entered SerialInterface constructor");
        }

        public void Disconnect()
        {
            if (keypadPort != null && keypadPort.IsOpen)
            {
                keypadPort.Close();
            }
            connectionEstablished = false;
        }

        public void ConnectToKeypad()
        {
            if ( Program.I_HAVE_A_KEYPAD )
            {
                ShowPorts();
                Console.WriteLine("Using COM4");
                keypadPort = new SerialPort("COM4", 9600);
                // Read signature to make sure we selected the keypad
                keypadPort.WriteLine("fun");
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
            }
            else
            {
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
            }
            /*Regex comRegex = new Regex(@"COM\d+$");
            while (comRegex.Matches(response = Console.ReadLine()).Count == 0)
            {
                Console.WriteLine("Invalid Response. Try again.");
            }
            response = "COM4";
            try
            {
                KeypadPort = new SerialPort(response, 9600);
                // Read signature to make sure we selected the keypad
                KeypadPort.WriteLine("fun");
                if (KeypadPort.ReadLine() == "orange")
                {
                    Console.WriteLine("Connection with keypad successfully established!");
                }
                else
                {
                    Console.WriteLine("Serial port did not respond with keypad signature");
                    Environment.Exit(-1);
                }
            } catch (System.IO.IOException) {
                Console.WriteLine("Connection with keypad successfully failed!");
                Environment.Exit(-1);
            }*/
        }

        public void EraseEEPROM() {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
            }
            else
            {
                Console.WriteLine("todo");
            }
        }
        public void SetDebounce(byte rising, byte falling, byte side) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
            }
            else
            {
                fakeEepromDebounceTimes[0] = rising;
                fakeEepromDebounceTimes[1] = falling;
                fakeEepromDebounceTimes[2] = side;
            }
        }
        public byte[] ReadDebounce() {
            if (!connectionEstablished) return new byte[0];
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
                return new byte[0];
            }
            else
            {
                var ret = new byte[3];
                Array.Copy(fakeEepromDebounceTimes, ret, 3);
                return ret;
            }
        }
        public void RemapLeftKey(byte keyCode) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
            }
            else
            {
                fakeEepromButtonMappings[0] = keyCode;
            }
        }
        public void RemapRightKey(byte keyCode) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
            }
            else
            {
                fakeEepromButtonMappings[1] = keyCode;
            }
        }
        public void RemapSideButton(byte keyCode) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
            }
            else
            {
                fakeEepromButtonMappings[2] = keyCode;
            }
        }
        public byte[] ReadKeybinds() {
            if (!connectionEstablished) return new byte[0];
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
                return new byte[] {5, 5, 40};
            }
            else
            {
                var ret = new byte[3];
                Array.Copy(fakeEepromButtonMappings, ret, 3);
                return ret;
            }
        }
        public void ActivateProfile() {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {

                Console.WriteLine("todo");
            }
            else
            {
                return;
            }
        }
        public int GetActiveProfile() {
            if (!connectionEstablished) return -1;
            if ( Program.I_HAVE_A_KEYPAD )
            {
                Console.WriteLine("todo");
                return 1;
            }
            else
            {
                return 1;
            }
        }
        public void ReadProfile(int whichProfile) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {

                Console.WriteLine("todo");
            }
            else
            {
                return;
            }
        }
        public void WriteProfile(int whichProfile) {
            if (!connectionEstablished) return;
            if ( Program.I_HAVE_A_KEYPAD )
            {

                Console.WriteLine("todo");
            }
            else
            {
                return;
            }
        }

        private void ShowPorts()
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
}
