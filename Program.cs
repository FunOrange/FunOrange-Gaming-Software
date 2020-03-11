using System;
using System.Text;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    static class Program
    {
        public static bool DEBUG = true;
        public static bool I_HAVE_A_KEYPAD = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var keypadSerial = new KeypadSerial(); 
            keypadSerial.ConnectToKeypad(); // search for keypad among currently plugged in devices

            // Testing basic usage of serial interface methods:
            Console.WriteLine("Initial: " + Encoding.Default.GetString(keypadSerial.ReadKeybinds())); // factory default keybinds
            keypadSerial.RemapLeftKey(67); // C
            keypadSerial.RemapRightKey(86); // V
            keypadSerial.RemapSideButton(83); // S
            Console.WriteLine("After remapping: " + Encoding.Default.GetString(keypadSerial.ReadKeybinds())); // remapped left key to keycode 90

            keypadSerial.Disconnect(); // keypad has been unplugged

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
