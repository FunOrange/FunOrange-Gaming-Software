using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    static class KeyConverter
    {
        private class KeyEntry
        {
            public string DisplayName;
            public string ScanCodeName;
            public byte ScanCode;
            public Keys KeyCode;

            public KeyEntry(string _displayName, string _scanCodeName, byte _scanCode, Keys _keyCode)
            {
                DisplayName = _displayName;
                ScanCodeName = _scanCodeName;
                ScanCode = _scanCode;
                KeyCode = _keyCode;
            }
        }

        private static List<KeyEntry> keyLookupTable;

        static KeyConverter()
        {
            keyLookupTable = new List<KeyEntry>();
            // key entries are added here
            // TODO: fill in KeyCodes (these can be found by ctrl-clicking into Keys type)
            keyLookupTable.Add(new KeyEntry("A", "HID_KEYBOARD_SC_A", 0x04, Keys.A));
            keyLookupTable.Add(new KeyEntry("B", "HID_KEYBOARD_SC_B", 0x05, Keys.B));
            keyLookupTable.Add(new KeyEntry("C", "HID_KEYBOARD_SC_C", 0x06, Keys.C));
            keyLookupTable.Add(new KeyEntry("D", "HID_KEYBOARD_SC_D", 0x07, Keys.D));
            keyLookupTable.Add(new KeyEntry("E", "HID_KEYBOARD_SC_E", 0x08, Keys.E));
            keyLookupTable.Add(new KeyEntry("F", "HID_KEYBOARD_SC_F", 0x09, Keys.F));
            keyLookupTable.Add(new KeyEntry("G", "HID_KEYBOARD_SC_G", 0x0A, Keys.G));
            keyLookupTable.Add(new KeyEntry("H", "HID_KEYBOARD_SC_H", 0x0B, Keys.H));
            keyLookupTable.Add(new KeyEntry("I", "HID_KEYBOARD_SC_I", 0x0C, Keys.I));
            keyLookupTable.Add(new KeyEntry("J", "HID_KEYBOARD_SC_J", 0x0D, Keys.J));
            keyLookupTable.Add(new KeyEntry("K", "HID_KEYBOARD_SC_K", 0x0E, Keys.K));
            keyLookupTable.Add(new KeyEntry("L", "HID_KEYBOARD_SC_L", 0x0F, Keys.L));
            keyLookupTable.Add(new KeyEntry("M", "HID_KEYBOARD_SC_M", 0x10, Keys.M));
            keyLookupTable.Add(new KeyEntry("N", "HID_KEYBOARD_SC_N", 0x11, Keys.N));
            keyLookupTable.Add(new KeyEntry("O", "HID_KEYBOARD_SC_O", 0x12, Keys.O));
            keyLookupTable.Add(new KeyEntry("P", "HID_KEYBOARD_SC_P", 0x13, Keys.P));
            keyLookupTable.Add(new KeyEntry("Q", "HID_KEYBOARD_SC_Q", 0x14, Keys.Q));
            keyLookupTable.Add(new KeyEntry("R", "HID_KEYBOARD_SC_R", 0x15, Keys.R));
            keyLookupTable.Add(new KeyEntry("S", "HID_KEYBOARD_SC_S", 0x16, Keys.S));
            keyLookupTable.Add(new KeyEntry("T", "HID_KEYBOARD_SC_T", 0x17, Keys.T));
            keyLookupTable.Add(new KeyEntry("U", "HID_KEYBOARD_SC_U", 0x18, Keys.U));
            keyLookupTable.Add(new KeyEntry("V", "HID_KEYBOARD_SC_V", 0x19, Keys.V));
            keyLookupTable.Add(new KeyEntry("W", "HID_KEYBOARD_SC_W", 0x1A, Keys.W));
            keyLookupTable.Add(new KeyEntry("X", "HID_KEYBOARD_SC_X", 0x1B, Keys.X));
            keyLookupTable.Add(new KeyEntry("Y", "HID_KEYBOARD_SC_Y", 0x1C, Keys.Y));
            keyLookupTable.Add(new KeyEntry("Z", "HID_KEYBOARD_SC_Z", 0x1D, Keys.Z));
            keyLookupTable.Add(new KeyEntry("1", "HID_KEYBOARD_SC_1_AND_EXCLAMATION", 0x1E, Keys.D1));
            keyLookupTable.Add(new KeyEntry("2", "HID_KEYBOARD_SC_2_AND_AT", 0x1F, Keys.D2));
            keyLookupTable.Add(new KeyEntry("3", "HID_KEYBOARD_SC_3_AND_HASHMARK", 0x20, Keys.D3));
            keyLookupTable.Add(new KeyEntry("4", "HID_KEYBOARD_SC_4_AND_DOLLAR", 0x21, Keys.D4));
            keyLookupTable.Add(new KeyEntry("5", "HID_KEYBOARD_SC_5_AND_PERCENTAGE", 0x22, Keys.D5));
            keyLookupTable.Add(new KeyEntry("6", "HID_KEYBOARD_SC_6_AND_CARET", 0x23, Keys.D6));
            keyLookupTable.Add(new KeyEntry("7", "HID_KEYBOARD_SC_7_AND_AMPERSAND", 0x24, Keys.D7));
            keyLookupTable.Add(new KeyEntry("8", "HID_KEYBOARD_SC_8_AND_ASTERISK", 0x25, Keys.D8));
            keyLookupTable.Add(new KeyEntry("9", "HID_KEYBOARD_SC_9_AND_OPENING_PARENTHESIS", 0x26, Keys.D9));
            keyLookupTable.Add(new KeyEntry("0", "HID_KEYBOARD_SC_0_AND_CLOSING_PARENTHESIS", 0x27, Keys.D0));
            keyLookupTable.Add(new KeyEntry("Enter", "HID_KEYBOARD_SC_ENTER", 0x28, Keys.Enter));
            keyLookupTable.Add(new KeyEntry("Esc", "HID_KEYBOARD_SC_ESCAPE", 0x29, Keys.Escape));
            keyLookupTable.Add(new KeyEntry("Backspc", "HID_KEYBOARD_SC_BACKSPACE", 0x2A, Keys.Back));
            keyLookupTable.Add(new KeyEntry("Tab", "HID_KEYBOARD_SC_TAB", 0x2B, Keys.Tab));
            keyLookupTable.Add(new KeyEntry("Space", "HID_KEYBOARD_SC_SPACE", 0x2C, Keys.Space));
            keyLookupTable.Add(new KeyEntry("-", "HID_KEYBOARD_SC_MINUS_AND_UNDERSCORE", 0x2D, Keys.OemMinus));
            keyLookupTable.Add(new KeyEntry("=", "HID_KEYBOARD_SC_EQUAL_AND_PLUS", 0x2E, Keys.Oemplus));
            keyLookupTable.Add(new KeyEntry("[", "HID_KEYBOARD_SC_OPENING_BRACKET_AND_OPENING_BRACE", 0x2F, Keys.OemOpenBrackets));
            keyLookupTable.Add(new KeyEntry("]", "HID_KEYBOARD_SC_CLOSING_BRACKET_AND_CLOSING_BRACE", 0x30, Keys.OemCloseBrackets));
            keyLookupTable.Add(new KeyEntry("\\", "HID_KEYBOARD_SC_BACKSLASH_AND_PIPE", 0x31, Keys.OemPipe));
            keyLookupTable.Add(new KeyEntry(";", "HID_KEYBOARD_SC_SEMICOLON_AND_COLON", 0x33, Keys.OemSemicolon));
            keyLookupTable.Add(new KeyEntry("''", "HID_KEYBOARD_SC_APOSTROPHE_AND_QUOTE", 0x34, Keys.OemQuotes));
            keyLookupTable.Add(new KeyEntry("`", "HID_KEYBOARD_SC_GRAVE_ACCENT_AND_TILDE", 0x35, Keys.Oemtilde));
            keyLookupTable.Add(new KeyEntry(",", "HID_KEYBOARD_SC_COMMA_AND_LESS_THAN_SIGN", 0x36, Keys.Oemcomma));
            keyLookupTable.Add(new KeyEntry(".", "HID_KEYBOARD_SC_DOT_AND_GREATER_THAN_SIGN", 0x37, Keys.OemPeriod));
            keyLookupTable.Add(new KeyEntry("/", "HID_KEYBOARD_SC_SLASH_AND_QUESTION_MARK", 0x38, Keys.OemQuestion));
            keyLookupTable.Add(new KeyEntry("F1", "HID_KEYBOARD_SC_F1", 0x3A, Keys.F1));
            keyLookupTable.Add(new KeyEntry("F2", "HID_KEYBOARD_SC_F2", 0x3B, Keys.F2));
            keyLookupTable.Add(new KeyEntry("F3", "HID_KEYBOARD_SC_F3", 0x3C, Keys.F3));
            keyLookupTable.Add(new KeyEntry("F4", "HID_KEYBOARD_SC_F4", 0x3D, Keys.F4));
            keyLookupTable.Add(new KeyEntry("F5", "HID_KEYBOARD_SC_F5", 0x3E, Keys.F5));
            keyLookupTable.Add(new KeyEntry("F6", "HID_KEYBOARD_SC_F6", 0x3F, Keys.F6));
            keyLookupTable.Add(new KeyEntry("F7", "HID_KEYBOARD_SC_F7", 0x40, Keys.F7));
            keyLookupTable.Add(new KeyEntry("F8", "HID_KEYBOARD_SC_F8", 0x41, Keys.F8));
            keyLookupTable.Add(new KeyEntry("F9", "HID_KEYBOARD_SC_F9", 0x42, Keys.F9));
            keyLookupTable.Add(new KeyEntry("F10", "HID_KEYBOARD_SC_F10", 0x43, Keys.F10));
            keyLookupTable.Add(new KeyEntry("F11", "HID_KEYBOARD_SC_F11", 0x44, Keys.F11));
            keyLookupTable.Add(new KeyEntry("F12", "HID_KEYBOARD_SC_F12", 0x45, Keys.F12));
            keyLookupTable.Add(new KeyEntry("PrtSc", "HID_KEYBOARD_SC_PRINT_SCREEN", 0x46, Keys.PrintScreen));
            keyLookupTable.Add(new KeyEntry("ScrLk", "HID_KEYBOARD_SC_SCROLL_LOCK", 0x47, Keys.Scroll));
            keyLookupTable.Add(new KeyEntry("Pause", "HID_KEYBOARD_SC_PAUSE", 0x48, Keys.Pause));
            keyLookupTable.Add(new KeyEntry("Ins", "HID_KEYBOARD_SC_INSERT", 0x49, Keys.Insert));
            keyLookupTable.Add(new KeyEntry("Home", "HID_KEYBOARD_SC_HOME", 0x4A, Keys.Home));
            keyLookupTable.Add(new KeyEntry("PgUp", "HID_KEYBOARD_SC_PAGE_UP", 0x4B, Keys.PageUp));
            keyLookupTable.Add(new KeyEntry("Del", "HID_KEYBOARD_SC_DELETE", 0x4C, Keys.Delete));
            keyLookupTable.Add(new KeyEntry("End", "HID_KEYBOARD_SC_END", 0x4D, Keys.End));
            keyLookupTable.Add(new KeyEntry("PgDn", "HID_KEYBOARD_SC_PAGE_DOWN", 0x4E, Keys.PageDown));
            keyLookupTable.Add(new KeyEntry("Right", "HID_KEYBOARD_SC_RIGHT_ARROW", 0x4F, Keys.Right));
            keyLookupTable.Add(new KeyEntry("Left", "HID_KEYBOARD_SC_LEFT_ARROW", 0x50, Keys.Left));
            keyLookupTable.Add(new KeyEntry("Down", "HID_KEYBOARD_SC_DOWN_ARROW", 0x51, Keys.Down));
            keyLookupTable.Add(new KeyEntry("Up", "HID_KEYBOARD_SC_UP_ARROW", 0x52, Keys.Up));
            keyLookupTable.Add(new KeyEntry("Num /", "HID_KEYBOARD_SC_KEYPAD_SLASH", 0x54, Keys.Divide));
            keyLookupTable.Add(new KeyEntry("Num *", "HID_KEYBOARD_SC_KEYPAD_ASTERISK", 0x55, Keys.Multiply));
            keyLookupTable.Add(new KeyEntry("Num -", "HID_KEYBOARD_SC_KEYPAD_MINUS", 0x56, Keys.Subtract));
            keyLookupTable.Add(new KeyEntry("Num +", "HID_KEYBOARD_SC_KEYPAD_PLUS", 0x57, Keys.Add));

            keyLookupTable.Add(new KeyEntry("Num 1", "HID_KEYBOARD_SC_KEYPAD_1_AND_END", 0x59, Keys.NumPad1));
            keyLookupTable.Add(new KeyEntry("Num 2", "HID_KEYBOARD_SC_KEYPAD_2_AND_DOWN_ARROW", 0x5A, Keys.NumPad2));
            keyLookupTable.Add(new KeyEntry("Num 3", "HID_KEYBOARD_SC_KEYPAD_3_AND_PAGE_DOWN", 0x5B, Keys.NumPad3));
            keyLookupTable.Add(new KeyEntry("Num 4", "HID_KEYBOARD_SC_KEYPAD_4_AND_LEFT_ARROW", 0x5C, Keys.NumPad4));
            keyLookupTable.Add(new KeyEntry("Num 5", "HID_KEYBOARD_SC_KEYPAD_5", 0x5D, Keys.NumPad5));
            keyLookupTable.Add(new KeyEntry("Num 6", "HID_KEYBOARD_SC_KEYPAD_6_AND_RIGHT_ARROW", 0x5E, Keys.NumPad6));
            keyLookupTable.Add(new KeyEntry("Num 7", "HID_KEYBOARD_SC_KEYPAD_7_AND_HOME", 0x5F, Keys.NumPad7));
            keyLookupTable.Add(new KeyEntry("Num 8", "HID_KEYBOARD_SC_KEYPAD_8_AND_UP_ARROW", 0x60, Keys.NumPad8));
            keyLookupTable.Add(new KeyEntry("Num 9", "HID_KEYBOARD_SC_KEYPAD_9_AND_PAGE_UP", 0x61, Keys.NumPad9));
            keyLookupTable.Add(new KeyEntry("Num 0", "HID_KEYBOARD_SC_KEYPAD_0_AND_INSERT", 0x62, Keys.NumPad0));
            keyLookupTable.Add(new KeyEntry("Num .", "HID_KEYBOARD_SC_KEYPAD_DOT_AND_DELETE", 0x63, Keys.Decimal));

            // TODO: look these ones up
            //keyLookupTable.Add(new KeyEntry("Kp Enter", "HID_KEYBOARD_SC_KEYPAD_ENTER", 0x58, Keys.)); 
            //keyLookupTable.Add(new KeyEntry("Kp =", "HID_KEYBOARD_SC_KEYPAD_EQUAL_SIGN", 0x67, Keys.));

#if these_keys_are_unused
            // keyLookupTable.Add(new KeyEntry("Num Lock", "HID_KEYBOARD_SC_NUM_LOCK", 0x53, Keys.));
            keyLookupTable.Add(new KeyEntry("KEYPAD_COMMA", "HID_KEYBOARD_SC_KEYPAD_COMMA", 0x85, Keys.));
            keyLookupTable.Add(new KeyEntry("NON_US_BACKSLASH_AND_PIPE", "HID_KEYBOARD_SC_NON_US_BACKSLASH_AND_PIPE", 0x64, Keys.));
            keyLookupTable.Add(new KeyEntry("APPLICATION", "HID_KEYBOARD_SC_APPLICATION", 0x65, Keys.));
            keyLookupTable.Add(new KeyEntry("NON_US_HASHMARK_AND_TILDE", "HID_KEYBOARD_SC_NON_US_HASHMARK_AND_TILDE", 0x32, Keys.));
            keyLookupTable.Add(new KeyEntry("CAPS_LOCK", "HID_KEYBOARD_SC_CAPS_LOCK", 0x39, Keys.));
#endif
        }

        public static byte ToScanCode(Keys keyCode)
        {
            var result = keyLookupTable.Find(e => e.KeyCode == keyCode);
            if (result != null)
            {
                return result.ScanCode;
            }
            return 0;
        }
        public static Keys ToKeyCode(byte scanCode)
        {
            var result = keyLookupTable.Find(e => e.ScanCode == scanCode);
            if (result != null)
            {
                return result.KeyCode;
            }
            return 0;
        }
    }
}
