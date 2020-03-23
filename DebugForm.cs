#define KP
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    public partial class DebugForm : Form
    {
        KeypadSerial keypadSerial;

        private Color UserColor;
        public DebugForm()
        {
            Console.WriteLine("Entered Form1 constructor");
            keypadSerial = new KeypadSerial();
            InitializeComponent();
            UserColor = Color.FromArgb(255, 128, 128);
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

        private async void button12_Click(object sender, EventArgs e)
        {
            PortTextBox.Text = "Searching...";
            PortTextBox.Text = await keypadSerial.GetPortInfo();
            if (PortTextBox.Text.Split('\n').Length >= 5)
                PortTextBox.ScrollBars = ScrollBars.Both;
            else
                PortTextBox.ScrollBars = ScrollBars.Horizontal;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Activate Profile");
            keypadSerial.SetActiveProfile((int) ActivateProfileControl.Value);
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
            var profile = keypadSerial.ReadProfile((int) ReadProfileControl.Value);
            Console.WriteLine();
            Console.WriteLine(profile);
            Console.WriteLine();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Writing a test profile to profile 1...");
            var p = new ReactiveProfile("Jun's test profile");
            p.DecayDuration = 10;
            p.Colors.Add(Color.FromArgb(255, 255, 0));
            p.Colors.Add(Color.FromArgb(0, 255, 255));
            Console.WriteLine(p);
            keypadSerial.WriteProfile(1, p);
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

        private void UserColorDisplay_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = true;
            colorPicker.FullOpen = true;
            colorPicker.Color = UserColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                UserColor = colorPicker.Color;
                UserColorDisplay.BackColor = UserColor;
                var profile = new CycleProfile("Single User Colour");
                profile.ColorDuration = 120;
                profile.Colors.Add(UserColor);
                keypadSerial.WriteProfile(5, profile);
                keypadSerial.SetActiveProfile(5);
            }
        }
    }
}
