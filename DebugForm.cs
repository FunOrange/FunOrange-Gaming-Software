﻿#undef KP
using System;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    public partial class DebugForm : Form
    {
        KeypadSerial keypadSerial;
        public DebugForm()
        {
            Console.WriteLine("Entered Form1 constructor");
            keypadSerial = new KeypadSerial();
            InitializeComponent();
#if !KP
            keypadSerial.ConnectToKeypad(COMPortControl.Text);
#endif
        }

        private void button_connect_keypad_Click(object sender, EventArgs e)
        {
            Console.WriteLine("connect keypad");
            keypadSerial.ConnectToKeypad(COMPortControl.Text);
        }

        private void button_disconnect_keypad_Click(object sender, EventArgs e)
        {
            keypadSerial.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keypadSerial.EraseEEPROM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte rise = (byte) SetRisingDebounceControl.Value;
            byte fall = (byte) SetFallingDebounceControl.Value;
            byte side = (byte) SetSideButtonDebounceControl.Value;
            keypadSerial.SetDebounce(rise, fall, side);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ret = keypadSerial.ReadDebounce();
            if (ret.Length == 3)
            {
                Console.WriteLine("Rising: " + ret[0]);
                Console.WriteLine("Falling: " + ret[1]);
                Console.WriteLine("Side: " + ret[2]);
                Console.WriteLine();
            }        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Remap Left Key");
            keypadSerial.RemapLeftKey((byte) RemapLeftKeyControl.Value);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            keypadSerial.ShowPorts();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Activate Profile");
            keypadSerial.ActivateProfile((int) ActivateProfileControl.Value);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Get Active Profile");
            int activeProfile = keypadSerial.GetActiveProfile();
            Console.WriteLine("Currently active profile is " + activeProfile);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Read Profile");
            keypadSerial.ReadProfile((int) ReadProfileControl.Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Write Profile");
            keypadSerial.WriteProfile(1, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Remap Right Key");
            keypadSerial.RemapRightKey((byte) RemapRightKeyControl.Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Remap Side Button");
            keypadSerial.RemapSideButton((byte) RemapSideButtonControl.Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Read Keybinds");
            var keybinds = keypadSerial.ReadKeybinds();
            Console.WriteLine("Left Keybind: " + keybinds[0]);
            Console.WriteLine("Right Keybind: " + keybinds[1]);
            Console.WriteLine("Side Keybind: " + keybinds[2]);
            Console.WriteLine();
        }

        private void DebugForm_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Keycode is {e.KeyCode}. ScanCode is {KeyConverter.ToScanCode(e.KeyCode)}");
        }
    }
}
