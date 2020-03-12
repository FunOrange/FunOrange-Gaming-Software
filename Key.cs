using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    class Key
    {
        private struct KeyEntry
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

        private List<KeyEntry> keyLookupTable;
        private static Key instance = null;

        public Key()
        {
            keyLookupTable = new List<KeyEntry>();
            // key entries are added here
            // TODO: fill in KeyCodes (these can be found by ctrl-clicking into Keys type
            keyLookupTable.Add(new KeyEntry("A", "HID_KEYBOARD_SC_A", 0x04, 0));
            keyLookupTable.Add(new KeyEntry("B", "HID_KEYBOARD_SC_B", 0x05, 0));
            keyLookupTable.Add(new KeyEntry("C", "HID_KEYBOARD_SC_C", 0x06, 0));
            keyLookupTable.Add(new KeyEntry("D", "HID_KEYBOARD_SC_D", 0x07, 0));
            keyLookupTable.Add(new KeyEntry("E", "HID_KEYBOARD_SC_E", 0x08, 0));
            keyLookupTable.Add(new KeyEntry("F", "HID_KEYBOARD_SC_F", 0x09, 0));
            keyLookupTable.Add(new KeyEntry("G", "HID_KEYBOARD_SC_G", 0x0A, 0));
            keyLookupTable.Add(new KeyEntry("H", "HID_KEYBOARD_SC_H", 0x0B, 0));
            keyLookupTable.Add(new KeyEntry("I", "HID_KEYBOARD_SC_I", 0x0C, 0));
            keyLookupTable.Add(new KeyEntry("J", "HID_KEYBOARD_SC_J", 0x0D, 0));
            keyLookupTable.Add(new KeyEntry("K", "HID_KEYBOARD_SC_K", 0x0E, 0));
            keyLookupTable.Add(new KeyEntry("L", "HID_KEYBOARD_SC_L", 0x0F, 0));
            keyLookupTable.Add(new KeyEntry("M", "HID_KEYBOARD_SC_M", 0x10, 0));
            keyLookupTable.Add(new KeyEntry("N", "HID_KEYBOARD_SC_N", 0x11, 0));
            keyLookupTable.Add(new KeyEntry("O", "HID_KEYBOARD_SC_O", 0x12, 0));
            keyLookupTable.Add(new KeyEntry("P", "HID_KEYBOARD_SC_P", 0x13, 0));
            keyLookupTable.Add(new KeyEntry("Q", "HID_KEYBOARD_SC_Q", 0x14, 0));
            keyLookupTable.Add(new KeyEntry("R", "HID_KEYBOARD_SC_R", 0x15, 0));
            keyLookupTable.Add(new KeyEntry("S", "HID_KEYBOARD_SC_S", 0x16, 0));
            keyLookupTable.Add(new KeyEntry("T", "HID_KEYBOARD_SC_T", 0x17, 0));
            keyLookupTable.Add(new KeyEntry("U", "HID_KEYBOARD_SC_U", 0x18, 0));
            keyLookupTable.Add(new KeyEntry("V", "HID_KEYBOARD_SC_V", 0x19, 0));
            keyLookupTable.Add(new KeyEntry("W", "HID_KEYBOARD_SC_W", 0x1A, 0));
            keyLookupTable.Add(new KeyEntry("X", "HID_KEYBOARD_SC_X", 0x1B, 0));
            keyLookupTable.Add(new KeyEntry("Y", "HID_KEYBOARD_SC_Y", 0x1C, 0));
            keyLookupTable.Add(new KeyEntry("Z", "HID_KEYBOARD_SC_Z", 0x1D, 0));
            keyLookupTable.Add(new KeyEntry("1", "HID_KEYBOARD_SC_1_AND_EXCLAMATION", 0x1E, 0));
            keyLookupTable.Add(new KeyEntry("2", "HID_KEYBOARD_SC_2_AND_AT", 0x1F, 0));
            keyLookupTable.Add(new KeyEntry("3", "HID_KEYBOARD_SC_3_AND_HASHMARK", 0x20, 0));
            keyLookupTable.Add(new KeyEntry("4", "HID_KEYBOARD_SC_4_AND_DOLLAR", 0x21, 0));
            keyLookupTable.Add(new KeyEntry("5", "HID_KEYBOARD_SC_5_AND_PERCENTAGE", 0x22, 0));
            keyLookupTable.Add(new KeyEntry("6", "HID_KEYBOARD_SC_6_AND_CARET", 0x23, 0));
            keyLookupTable.Add(new KeyEntry("7", "HID_KEYBOARD_SC_7_AND_AMPERSAND", 0x24, 0));
            keyLookupTable.Add(new KeyEntry("8", "HID_KEYBOARD_SC_8_AND_ASTERISK", 0x25, 0));
            keyLookupTable.Add(new KeyEntry("9", "HID_KEYBOARD_SC_9_AND_OPENING_PARENTHESIS", 0x26, 0));
            keyLookupTable.Add(new KeyEntry("0", "HID_KEYBOARD_SC_0_AND_CLOSING_PARENTHESIS", 0x27, 0));
            keyLookupTable.Add(new KeyEntry("Enter", "HID_KEYBOARD_SC_ENTER", 0x28, 0));
            keyLookupTable.Add(new KeyEntry("Escape", "HID_KEYBOARD_SC_ESCAPE", 0x29, 0));
            keyLookupTable.Add(new KeyEntry("Backspace", "HID_KEYBOARD_SC_BACKSPACE", 0x2A, 0));
            keyLookupTable.Add(new KeyEntry("Tab", "HID_KEYBOARD_SC_TAB", 0x2B, 0));
            keyLookupTable.Add(new KeyEntry("Space", "HID_KEYBOARD_SC_SPACE", 0x2C, 0));
            keyLookupTable.Add(new KeyEntry("-", "HID_KEYBOARD_SC_MINUS_AND_UNDERSCORE", 0x2D, 0));
            keyLookupTable.Add(new KeyEntry("=", "HID_KEYBOARD_SC_EQUAL_AND_PLUS", 0x2E, 0));
            keyLookupTable.Add(new KeyEntry("[", "HID_KEYBOARD_SC_OPENING_BRACKET_AND_OPENING_BRACE", 0x2F, 0));
            keyLookupTable.Add(new KeyEntry("]", "HID_KEYBOARD_SC_CLOSING_BRACKET_AND_CLOSING_BRACE", 0x30, 0));
            keyLookupTable.Add(new KeyEntry("\\", "HID_KEYBOARD_SC_BACKSLASH_AND_PIPE", 0x31, 0));
            keyLookupTable.Add(new KeyEntry(";", "HID_KEYBOARD_SC_SEMICOLON_AND_COLON", 0x33, 0));
            keyLookupTable.Add(new KeyEntry("''", "HID_KEYBOARD_SC_APOSTROPHE_AND_QUOTE", 0x34, 0));
            keyLookupTable.Add(new KeyEntry("`", "HID_KEYBOARD_SC_GRAVE_ACCENT_AND_TILDE", 0x35, 0));
            keyLookupTable.Add(new KeyEntry(",", "HID_KEYBOARD_SC_COMMA_AND_LESS_THAN_SIGN", 0x36, 0));
            keyLookupTable.Add(new KeyEntry(".", "HID_KEYBOARD_SC_DOT_AND_GREATER_THAN_SIGN", 0x37, 0));
            keyLookupTable.Add(new KeyEntry("/", "HID_KEYBOARD_SC_SLASH_AND_QUESTION_MARK", 0x38, 0));
            keyLookupTable.Add(new KeyEntry("F1", "HID_KEYBOARD_SC_F1", 0x3A, 0));
            keyLookupTable.Add(new KeyEntry("F2", "HID_KEYBOARD_SC_F2", 0x3B, 0));
            keyLookupTable.Add(new KeyEntry("F3", "HID_KEYBOARD_SC_F3", 0x3C, 0));
            keyLookupTable.Add(new KeyEntry("F4", "HID_KEYBOARD_SC_F4", 0x3D, 0));
            keyLookupTable.Add(new KeyEntry("F5", "HID_KEYBOARD_SC_F5", 0x3E, 0));
            keyLookupTable.Add(new KeyEntry("F6", "HID_KEYBOARD_SC_F6", 0x3F, 0));
            keyLookupTable.Add(new KeyEntry("F7", "HID_KEYBOARD_SC_F7", 0x40, 0));
            keyLookupTable.Add(new KeyEntry("F8", "HID_KEYBOARD_SC_F8", 0x41, 0));
            keyLookupTable.Add(new KeyEntry("F9", "HID_KEYBOARD_SC_F9", 0x42, 0));
            keyLookupTable.Add(new KeyEntry("F10", "HID_KEYBOARD_SC_F10", 0x43, 0));
            keyLookupTable.Add(new KeyEntry("F11", "HID_KEYBOARD_SC_F11", 0x44, 0));
            keyLookupTable.Add(new KeyEntry("F12", "HID_KEYBOARD_SC_F12", 0x45, 0));
            keyLookupTable.Add(new KeyEntry("PrtSc", "HID_KEYBOARD_SC_PRINT_SCREEN", 0x46, 0));
            keyLookupTable.Add(new KeyEntry("ScrLk", "HID_KEYBOARD_SC_SCROLL_LOCK", 0x47, 0));
            keyLookupTable.Add(new KeyEntry("Pause", "HID_KEYBOARD_SC_PAUSE", 0x48, 0));
            keyLookupTable.Add(new KeyEntry("Ins", "HID_KEYBOARD_SC_INSERT", 0x49, 0));
            keyLookupTable.Add(new KeyEntry("Home", "HID_KEYBOARD_SC_HOME", 0x4A, 0));
            keyLookupTable.Add(new KeyEntry("PgUp", "HID_KEYBOARD_SC_PAGE_UP", 0x4B, 0));
            keyLookupTable.Add(new KeyEntry("Del", "HID_KEYBOARD_SC_DELETE", 0x4C, 0));
            keyLookupTable.Add(new KeyEntry("End", "HID_KEYBOARD_SC_END", 0x4D, 0));
            keyLookupTable.Add(new KeyEntry("PgDn", "HID_KEYBOARD_SC_PAGE_DOWN", 0x4E, 0));
            keyLookupTable.Add(new KeyEntry("Right", "HID_KEYBOARD_SC_RIGHT_ARROW", 0x4F, 0));
            keyLookupTable.Add(new KeyEntry("Left", "HID_KEYBOARD_SC_LEFT_ARROW", 0x50, 0));
            keyLookupTable.Add(new KeyEntry("Down", "HID_KEYBOARD_SC_DOWN_ARROW", 0x51, 0));
            keyLookupTable.Add(new KeyEntry("Up", "HID_KEYBOARD_SC_UP_ARROW", 0x52, 0));
            // keyLookupTable.Add(new KeyEntry("Num Lock", "HID_KEYBOARD_SC_NUM_LOCK", 0x53, 0));
            keyLookupTable.Add(new KeyEntry("Kp /", "HID_KEYBOARD_SC_KEYPAD_SLASH", 0x54, 0));
            keyLookupTable.Add(new KeyEntry("Kp *", "HID_KEYBOARD_SC_KEYPAD_ASTERISK", 0x55, 0));
            keyLookupTable.Add(new KeyEntry("Kp -", "HID_KEYBOARD_SC_KEYPAD_MINUS", 0x56, 0));
            keyLookupTable.Add(new KeyEntry("Kp +", "HID_KEYBOARD_SC_KEYPAD_PLUS", 0x57, 0));
            keyLookupTable.Add(new KeyEntry("Kp Enter", "HID_KEYBOARD_SC_KEYPAD_ENTER", 0x58, 0));
            keyLookupTable.Add(new KeyEntry("Kp 1", "HID_KEYBOARD_SC_KEYPAD_1_AND_END", 0x59, 0));
            keyLookupTable.Add(new KeyEntry("Kp 2", "HID_KEYBOARD_SC_KEYPAD_2_AND_DOWN_ARROW", 0x5A, 0));
            keyLookupTable.Add(new KeyEntry("Kp 3", "HID_KEYBOARD_SC_KEYPAD_3_AND_PAGE_DOWN", 0x5B, 0));
            keyLookupTable.Add(new KeyEntry("Kp 4", "HID_KEYBOARD_SC_KEYPAD_4_AND_LEFT_ARROW", 0x5C, 0));
            keyLookupTable.Add(new KeyEntry("Kp 5", "HID_KEYBOARD_SC_KEYPAD_5", 0x5D, 0));
            keyLookupTable.Add(new KeyEntry("Kp 6", "HID_KEYBOARD_SC_KEYPAD_6_AND_RIGHT_ARROW", 0x5E, 0));
            keyLookupTable.Add(new KeyEntry("Kp 7", "HID_KEYBOARD_SC_KEYPAD_7_AND_HOME", 0x5F, 0));
            keyLookupTable.Add(new KeyEntry("Kp 8", "HID_KEYBOARD_SC_KEYPAD_8_AND_UP_ARROW", 0x60, 0));
            keyLookupTable.Add(new KeyEntry("Kp 9", "HID_KEYBOARD_SC_KEYPAD_9_AND_PAGE_UP", 0x61, 0));
            keyLookupTable.Add(new KeyEntry("Kp 0", "HID_KEYBOARD_SC_KEYPAD_0_AND_INSERT", 0x62, 0));
            keyLookupTable.Add(new KeyEntry("Kp .", "HID_KEYBOARD_SC_KEYPAD_DOT_AND_DELETE", 0x63, 0));
            keyLookupTable.Add(new KeyEntry("Kp =", "HID_KEYBOARD_SC_KEYPAD_EQUAL_SIGN", 0x67, 0));
            // keyLookupTable.Add(new KeyEntry("KEYPAD_COMMA", "HID_KEYBOARD_SC_KEYPAD_COMMA", 0x85, 0));
            // keyLookupTable.Add(new KeyEntry("NON_US_BACKSLASH_AND_PIPE", "HID_KEYBOARD_SC_NON_US_BACKSLASH_AND_PIPE", 0x64, 0));
            // keyLookupTable.Add(new KeyEntry("APPLICATION", "HID_KEYBOARD_SC_APPLICATION", 0x65, 0));
            // keyLookupTable.Add(new KeyEntry("NON_US_HASHMARK_AND_TILDE", "HID_KEYBOARD_SC_NON_US_HASHMARK_AND_TILDE", 0x32, 0));
            // keyLookupTable.Add(new KeyEntry("CAPS_LOCK", "HID_KEYBOARD_SC_CAPS_LOCK", 0x39, 0));
        }

        public byte KeyToScan(System.Windows.Forms.Keys key)
        {
            if (instance == null)
                instance = new Key();
            return 0;
        }
        public System.Windows.Forms.Keys ScanToKey(byte scanCode)
        {
            if (instance == null)
                instance = new Key();
            return 0;
        }
    }
}
