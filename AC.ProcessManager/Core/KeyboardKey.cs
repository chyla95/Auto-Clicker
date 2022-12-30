using System.Runtime.Versioning;
using static AC.ProcessManager.Utilities.Wrappers.Keyboard;
using static AC.ProcessManager.Utilities.Wrappers.Window;
namespace AC.ProcessManager.Core
{
    public enum KeyCode : uint
    {
        // Control-break processing
        VK_CANCEL = 0x03,
        // BACKSPACE keyCode
        VK_BACK = 0x08,
        // TAB keyCode
        VK_TAB = 0x09,
        // CLEAR keyCode
        VK_CLEAR = 0x0C,
        // ENTER keyCode
        VK_RETURN = 0x0D,
        // SHIFT keyCode
        VK_SHIFT = 0x10,
        // CTRL keyCode
        VK_CONTROL = 0x11,
        // ALT keyCode
        VK_MENU = 0x12,
        // PAUSE keyCode
        VK_PAUSE = 0x13,
        // CAPS LOCK keyCode
        VK_CAPITAL = 0x14,
        // IME Kana mode
        VK_KANA = 0x15,
        // IME Hanguel mode (maintained for compatibility; use <code>VK_HANGUL</code>)
        VK_HANGUEL = 0x15,
        // IME Hangul mode
        VK_HANGUL = 0x15,
        // IME On
        VK_IME_ON = 0x16,
        // IME Junja mode
        VK_JUNJA = 0x17,
        // IME final mode
        VK_FINAL = 0x18,
        // IME Hanja mode
        VK_HANJA = 0x19,
        // IME Kanji mode
        VK_KANJI = 0x19,
        // IME Off
        VK_IME_OFF = 0x1A,
        // ESC keyCode
        VK_ESCAPE = 0x1B,
        // IME convert
        VK_CONVERT = 0x1C,
        // IME nonconvert
        VK_NONCONVERT = 0x1D,
        // IME accept
        VK_ACCEPT = 0x1E,
        // IME mode change request
        VK_MODECHANGE = 0x1F,
        // SPACEBAR
        VK_SPACE = 0x20,
        // PAGE UP keyCode
        VK_PRIOR = 0x21,
        // PAGE DOWN keyCode
        VK_NEXT = 0x22,
        // END keyCode
        VK_END = 0x23,
        // HOME keyCode
        VK_HOME = 0x24,
        // LEFT ARROW keyCode
        VK_LEFT = 0x25,
        // UP ARROW keyCode
        VK_UP = 0x26,
        // RIGHT ARROW keyCode
        VK_RIGHT = 0x27,
        // DOWN ARROW keyCode
        VK_DOWN = 0x28,
        // SELECT keyCode
        VK_SELECT = 0x29,
        // PRINT keyCode
        VK_PRINT = 0x2A,
        // EXECUTE keyCode
        VK_EXECUTE = 0x2B,
        // PRINT SCREEN keyCode
        VK_SNAPSHOT = 0x2C,
        // INS keyCode
        VK_INSERT = 0x2D,
        // DEL keyCode
        VK_DELETE = 0x2E,
        // HELP keyCode
        VK_HELP = 0x2F,
        // 0 keyCode
        VK_0 = 0x30,
        // 1 keyCode
        VK_1 = 0x31,
        // 2 keyCode
        VK_2 = 0x32,
        // 3 keyCode
        VK_3 = 0x33,
        // 4 keyCode
        VK_4 = 0x34,
        // 5 keyCode
        VK_5 = 0x35,
        // 6 keyCode
        VK_6 = 0x36,
        // 7 keyCode
        VK_7 = 0x37,
        // 8 keyCode
        VK_8 = 0x38,
        // 9 keyCode
        VK_9 = 0x39,
        // A keyCode
        VK_A = 0x41,
        // B keyCode
        VK_B = 0x42,
        // C keyCode
        VK_C = 0x43,
        // D keyCode
        VK_D = 0x44,
        // E keyCode
        VK_E = 0x45,
        // F keyCode
        VK_F = 0x46,
        // G keyCode
        VK_G = 0x47,
        // H keyCode
        VK_H = 0x48,
        // I keyCode
        VK_I = 0x49,
        // J keyCode
        VK_J = 0x4A,
        // K keyCode
        VK_K = 0x4B,
        // L keyCode
        VK_L = 0x4C,
        // M keyCode
        VK_M = 0x4D,
        // N keyCode
        VK_N = 0x4E,
        // O keyCode
        VK_O = 0x4F,
        // P keyCode
        VK_P = 0x50,
        // Q keyCode
        VK_Q = 0x51,
        // R keyCode
        VK_R = 0x52,
        // S keyCode
        VK_S = 0x53,
        // T keyCode
        VK_T = 0x54,
        // U keyCode
        VK_U = 0x55,
        // V keyCode
        VK_V = 0x56,
        // W keyCode
        VK_W = 0x57,
        // X keyCode
        VK_X = 0x58,
        // Y keyCode
        VK_Y = 0x59,
        // Z keyCode
        VK_Z = 0x5A,
        // Left Windows keyCode (Natural keyboard)
        VK_LWIN = 0x5B,
        // Right Windows keyCode (Natural keyboard)
        VK_RWIN = 0x5C,
        // Applications keyCode (Natural keyboard)
        VK_APPS = 0x5D,
        // Computer Sleep keyCode
        VK_SLEEP = 0x5F,
        // Numeric keypad 0 keyCode
        VK_NUMPAD0 = 0x60,
        // Numeric keypad 1 keyCode
        VK_NUMPAD1 = 0x61,
        // Numeric keypad 2 keyCode
        VK_NUMPAD2 = 0x62,
        // Numeric keypad 3 keyCode
        VK_NUMPAD3 = 0x63,
        // Numeric keypad 4 keyCode
        VK_NUMPAD4 = 0x64,
        // Numeric keypad 5 keyCode
        VK_NUMPAD5 = 0x65,
        // Numeric keypad 6 keyCode
        VK_NUMPAD6 = 0x66,
        // Numeric keypad 7 keyCode
        VK_NUMPAD7 = 0x67,
        // Numeric keypad 8 keyCode
        VK_NUMPAD8 = 0x68,
        // Numeric keypad 9 keyCode
        VK_NUMPAD9 = 0x69,
        // Multiply keyCode
        VK_MULTIPLY = 0x6A,
        // Add keyCode
        VK_ADD = 0x6B,
        // Separator keyCode
        VK_SEPARATOR = 0x6C,
        // Subtract keyCode
        VK_SUBTRACT = 0x6D,
        // Decimal keyCode
        VK_DECIMAL = 0x6E,
        // Divide keyCode
        VK_DIVIDE = 0x6F,
        // F1 keyCode
        VK_F1 = 0x70,
        // F2 keyCode
        VK_F2 = 0x71,
        // F3 keyCode
        VK_F3 = 0x72,
        // F4 keyCode
        VK_F4 = 0x73,
        // F5 keyCode
        VK_F5 = 0x74,
        // F6 keyCode
        VK_F6 = 0x75,
        // F7 keyCode
        VK_F7 = 0x76,
        // F8 keyCode
        VK_F8 = 0x77,
        // F9 keyCode
        VK_F9 = 0x78,
        // F10 keyCode
        VK_F10 = 0x79,
        // F11 keyCode
        VK_F11 = 0x7A,
        // F12 keyCode
        VK_F12 = 0x7B,
        // F13 keyCode
        VK_F13 = 0x7C,
        // F14 keyCode
        VK_F14 = 0x7D,
        // F15 keyCode
        VK_F15 = 0x7E,
        // F16 keyCode
        VK_F16 = 0x7F,
        // F17 keyCode
        VK_F17 = 0x80,
        // F18 keyCode
        VK_F18 = 0x81,
        // F19 keyCode
        VK_F19 = 0x82,
        // F20 keyCode
        VK_F20 = 0x83,
        // F21 keyCode
        VK_F21 = 0x84,
        // F22 keyCode
        VK_F22 = 0x85,
        // F23 keyCode
        VK_F23 = 0x86,
        // F24 keyCode
        VK_F24 = 0x87,
        // NUM LOCK keyCode
        VK_NUMLOCK = 0x90,
        // SCROLL LOCK keyCode
        VK_SCROLL = 0x91,
        // Left SHIFT keyCode
        VK_LSHIFT = 0xA0,
        // Right SHIFT keyCode
        VK_RSHIFT = 0xA1,
        // Left CONTROL keyCode
        VK_LCONTROL = 0xA2,
        // Right CONTROL keyCode
        VK_RCONTROL = 0xA3,
        // Left ALT keyCode
        VK_LMENU = 0xA4,
        // Right ALT keyCode
        VK_RMENU = 0xA5,
        // Browser Back keyCode
        VK_BROWSER_BACK = 0xA6,
        // Browser Forward keyCode
        VK_BROWSER_FORWARD = 0xA7,
        // Browser Refresh keyCode
        VK_BROWSER_REFRESH = 0xA8,
        // Browser Stop keyCode
        VK_BROWSER_STOP = 0xA9,
        // Browser Search keyCode
        VK_BROWSER_SEARCH = 0xAA,
        // Browser Favorites keyCode
        VK_BROWSER_FAVORITES = 0xAB,
        // Browser Start and Home keyCode
        VK_BROWSER_HOME = 0xAC,
        // Volume Mute keyCode
        VK_VOLUME_MUTE = 0xAD,
        // Volume Down keyCode
        VK_VOLUME_DOWN = 0xAE,
        // Volume Up keyCode
        VK_VOLUME_UP = 0xAF,
        // Next Track keyCode
        VK_MEDIA_NEXT_TRACK = 0xB0,
        // Previous Track keyCode
        VK_MEDIA_PREV_TRACK = 0xB1,
        // Stop Media keyCode
        VK_MEDIA_STOP = 0xB2,
        // Play/Pause Media keyCode
        VK_MEDIA_PLAY_PAUSE = 0xB3,
        // Start Mail keyCode
        VK_LAUNCH_MAIL = 0xB4,
        // Select Media keyCode
        VK_LAUNCH_MEDIA_SELECT = 0xB5,
        // Start Application 1 keyCode
        VK_LAUNCH_APP1 = 0xB6,
        // Start Application 2 keyCode
        VK_LAUNCH_APP2 = 0xB7,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' keyCode
        VK_OEM_1 = 0xBA,
        // For any country/region, the '+' keyCode
        VK_OEM_PLUS = 0xBB,
        // For any country/region, the ',' keyCode
        VK_OEM_COMMA = 0xBC,
        // For any country/region, the '-' keyCode
        VK_OEM_MINUS = 0xBD,
        // For any country/region, the '.' keyCode
        VK_OEM_PERIOD = 0xBE,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' keyCode
        VK_OEM_2 = 0xBF,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' keyCode
        VK_OEM_3 = 0xC0,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' keyCode
        VK_OEM_4 = 0xDB,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\|' keyCode
        VK_OEM_5 = 0xDC,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' keyCode
        VK_OEM_6 = 0xDD,
        // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' keyCode
        VK_OEM_7 = 0xDE,
        // Used for miscellaneous characters; it can vary by keyboard.
        VK_OEM_8 = 0xDF,
        // The <code>&lt;&gt;</code> keys on the US standard keyboard, or the <code>\\|</code> keyCode on the non-US 102-keyCode keyboard
        VK_OEM_102 = 0xE2,
        // IME PROCESS keyCode
        VK_PROCESSKEY = 0xE5,
        // Used to pass Unicode characters as if they were keystrokes. The <code>VK_PACKET</code> keyCode is the low word of a 32-bit Virtual KeyId value used for non-keyboard input methods. For more information, see Remark in <a href="/en-us/windows/win32/api/winuser/ns-winuser-keybdinput" data-linktype="absolute-path"><code>KEYBDINPUT</code></a>, <a href="/en-us/windows/win32/api/winuser/nf-winuser-sendinput" data-linktype="absolute-path"><code>SendInput</code></a>, <a href="wm-keydown" data-linktype="relative-path"><code>WM_KEYDOWN</code></a>, and <a href="wm-keyup" data-linktype="relative-path"><code>WM_KEYUP</code></a>
        VK_PACKET = 0xE7,
        // Attn keyCode
        VK_ATTN = 0xF6,
        // CrSel keyCode
        VK_CRSEL = 0xF7,
        // ExSel keyCode
        VK_EXSEL = 0xF8,
        // Erase EOF keyCode
        VK_EREOF = 0xF9,
        // Play keyCode
        VK_PLAY = 0xFA,
        // Zoom keyCode
        VK_ZOOM = 0xFB,
        // Reserved
        VK_NONAME = 0xFC,
        // PA1 keyCode
        VK_PA1 = 0xFD,
        // Clear keyCode
        VK_OEM_CLEAR = 0xFE,
    }
    public enum KeyId : uint
    {
        //
        // Summary:
        //     No virtual keyId value.
        None = 0,
        //
        // Summary:
        //     The left mouse button.
        LeftButton = 1,
        //
        // Summary:
        //     The right mouse button.
        RightButton = 2,
        //
        // Summary:
        //     The cancel keyId or button
        Cancel = 3,
        //
        // Summary:
        //     The middle mouse button.
        MiddleButton = 4,
        //
        // Summary:
        //     An additional "extended" device keyId or button (for example, an additional mouse
        //     button).
        XButton1 = 5,
        //
        // Summary:
        //     An additional "extended" device keyId or button (for example, an additional mouse
        //     button).
        XButton2 = 6,
        //
        // Summary:
        //     The virtual back keyId or button.
        Back = 8,
        //
        // Summary:
        //     The Tab keyId.
        Tab = 9,
        //
        // Summary:
        //     The Clear keyId or button.
        Clear = 12,
        //
        // Summary:
        //     The Enter keyId.
        Enter = 13,
        //
        // Summary:
        //     The Shift keyId. This is the general Shift case, applicable to keyId layouts with
        //     only one Shift keyId or that do not need to differentiate between left Shift and
        //     right Shift keystrokes.
        Shift = 0x10,
        //
        // Summary:
        //     The Ctrl keyId. This is the general Ctrl case, applicable to keyId layouts with only
        //     one Ctrl keyId or that do not need to differentiate between left Ctrl and right
        //     Ctrl keystrokes.
        Control = 17,
        //
        // Summary:
        //     The menu keyId or button.
        Menu = 18,
        //
        // Summary:
        //     The Pause keyId or button.
        Pause = 19,
        //
        // Summary:
        //     The Caps Lock keyId or button.
        CapitalLock = 20,
        //
        // Summary:
        //     The Kana symbol keyId-shift button
        Kana = 21,
        //
        // Summary:
        //     The Hangul symbol keyId-shift button.
        Hangul = 21,
        //
        // Summary:
        //     The Junja symbol keyId-shift button.
        Junja = 23,
        //
        // Summary:
        //     The Final symbol keyId-shift button.
        Final = 24,
        //
        // Summary:
        //     The Hanja symbol keyId shift button.
        Hanja = 25,
        //
        // Summary:
        //     The Kanji symbol keyId-shift button.
        Kanji = 25,
        //
        // Summary:
        //     The Esc keyId.
        Escape = 27,
        //
        // Summary:
        //     The convert button or keyId.
        Convert = 28,
        //
        // Summary:
        //     The nonconvert button or keyId.
        NonConvert = 29,
        //
        // Summary:
        //     The accept button or keyId.
        Accept = 30,
        //
        // Summary:
        //     The mode change keyId.
        ModeChange = 0x1F,
        //
        // Summary:
        //     The Spacebar keyId or button.
        Space = 0x20,
        //
        // Summary:
        //     The Page Up keyId.
        PageUp = 33,
        //
        // Summary:
        //     The Page Down keyId.
        PageDown = 34,
        //
        // Summary:
        //     The End keyId.
        End = 35,
        //
        // Summary:
        //     The Home keyId.
        Home = 36,
        //
        // Summary:
        //     The Left Arrow keyId.
        Left = 37,
        //
        // Summary:
        //     The Up Arrow keyId.
        Up = 38,
        //
        // Summary:
        //     The Right Arrow keyId.
        Right = 39,
        //
        // Summary:
        //     The Down Arrow keyId.
        Down = 40,
        //
        // Summary:
        //     The Select keyId or button.
        Select = 41,
        //
        // Summary:
        //     The Print keyId or button.
        Print = 42,
        //
        // Summary:
        //     The execute keyId or button.
        Execute = 43,
        //
        // Summary:
        //     The snapshot keyId or button.
        Snapshot = 44,
        //
        // Summary:
        //     The Insert keyId.
        Insert = 45,
        //
        // Summary:
        //     The Delete keyId.
        Delete = 46,
        //
        // Summary:
        //     The Help keyId or button.
        Help = 47,
        //
        // Summary:
        //     The number "0" keyId.
        Number0 = 48,
        //
        // Summary:
        //     The number "1" keyId.
        Number1 = 49,
        //
        // Summary:
        //     The number "2" keyId.
        Number2 = 50,
        //
        // Summary:
        //     The number "3" keyId.
        Number3 = 51,
        //
        // Summary:
        //     The number "4" keyId.
        Number4 = 52,
        //
        // Summary:
        //     The number "5" keyId.
        Number5 = 53,
        //
        // Summary:
        //     The number "6" keyId.
        Number6 = 54,
        //
        // Summary:
        //     The number "7" keyId.
        Number7 = 55,
        //
        // Summary:
        //     The number "8" keyId.
        Number8 = 56,
        //
        // Summary:
        //     The number "9" keyId.
        Number9 = 57,
        //
        // Summary:
        //     The letter "A" keyId.
        A = 65,
        //
        // Summary:
        //     The letter "B" keyId.
        B = 66,
        //
        // Summary:
        //     The letter "C" keyId.
        C = 67,
        //
        // Summary:
        //     The letter "D" keyId.
        D = 68,
        //
        // Summary:
        //     The letter "E" keyId.
        E = 69,
        //
        // Summary:
        //     The letter "F" keyId.
        F = 70,
        //
        // Summary:
        //     The letter "G" keyId.
        G = 71,
        //
        // Summary:
        //     The letter "H" keyId.
        H = 72,
        //
        // Summary:
        //     The letter "I" keyId.
        I = 73,
        //
        // Summary:
        //     The letter "J" keyId.
        J = 74,
        //
        // Summary:
        //     The letter "K" keyId.
        K = 75,
        //
        // Summary:
        //     The letter "L" keyId.
        L = 76,
        //
        // Summary:
        //     The letter "M" keyId.
        M = 77,
        //
        // Summary:
        //     The letter "N" keyId.
        N = 78,
        //
        // Summary:
        //     The letter "O" keyId.
        O = 79,
        //
        // Summary:
        //     The letter "P" keyId.
        P = 80,
        //
        // Summary:
        //     The letter "Q" keyId.
        Q = 81,
        //
        // Summary:
        //     The letter "R" keyId.
        R = 82,
        //
        // Summary:
        //     The letter "S" keyId.
        S = 83,
        //
        // Summary:
        //     The letter "T" keyId.
        T = 84,
        //
        // Summary:
        //     The letter "U" keyId.
        U = 85,
        //
        // Summary:
        //     The letter "V" keyId.
        V = 86,
        //
        // Summary:
        //     The letter "W" keyId.
        W = 87,
        //
        // Summary:
        //     The letter "X" keyId.
        X = 88,
        //
        // Summary:
        //     The letter "Y" keyId.
        Y = 89,
        //
        // Summary:
        //     The letter "Z" keyId.
        Z = 90,
        //
        // Summary:
        //     The left Windows keyId.
        LeftWindows = 91,
        //
        // Summary:
        //     The right Windows keyId.
        RightWindows = 92,
        //
        // Summary:
        //     The application keyId or button.
        Application = 93,
        //
        // Summary:
        //     The sleep keyId or button.
        Sleep = 95,
        //
        // Summary:
        //     The number "0" keyId as located on a numeric pad.
        NumberPad0 = 96,
        //
        // Summary:
        //     The number "1" keyId as located on a numeric pad.
        NumberPad1 = 97,
        //
        // Summary:
        //     The number "2" keyId as located on a numeric pad.
        NumberPad2 = 98,
        //
        // Summary:
        //     The number "3" keyId as located on a numeric pad.
        NumberPad3 = 99,
        //
        // Summary:
        //     The number "4" keyId as located on a numeric pad.
        NumberPad4 = 100,
        //
        // Summary:
        //     The number "5" keyId as located on a numeric pad.
        NumberPad5 = 101,
        //
        // Summary:
        //     The number "6" keyId as located on a numeric pad.
        NumberPad6 = 102,
        //
        // Summary:
        //     The number "7" keyId as located on a numeric pad.
        NumberPad7 = 103,
        //
        // Summary:
        //     The number "8" keyId as located on a numeric pad.
        NumberPad8 = 104,
        //
        // Summary:
        //     The number "9" keyId as located on a numeric pad.
        NumberPad9 = 105,
        //
        // Summary:
        //     The multiply (*) operation keyId as located on a numeric pad.
        Multiply = 106,
        //
        // Summary:
        //     The add (+) operation keyId as located on a numeric pad.
        Add = 107,
        //
        // Summary:
        //     The separator keyId as located on a numeric pad.
        Separator = 108,
        //
        // Summary:
        //     The subtract (-) operation keyId as located on a numeric pad.
        Subtract = 109,
        //
        // Summary:
        //     The decimal (.) keyId as located on a numeric pad.
        Decimal = 110,
        //
        // Summary:
        //     The divide (/) operation keyId as located on a numeric pad.
        Divide = 111,
        //
        // Summary:
        //     The F1 function keyId.
        F1 = 112,
        //
        // Summary:
        //     The F2 function keyId.
        F2 = 113,
        //
        // Summary:
        //     The F3 function keyId.
        F3 = 114,
        //
        // Summary:
        //     The F4 function keyId.
        F4 = 115,
        //
        // Summary:
        //     The F5 function keyId.
        F5 = 116,
        //
        // Summary:
        //     The F6 function keyId.
        F6 = 117,
        //
        // Summary:
        //     The F7 function keyId.
        F7 = 118,
        //
        // Summary:
        //     The F8 function keyId.
        F8 = 119,
        //
        // Summary:
        //     The F9 function keyId.
        F9 = 120,
        //
        // Summary:
        //     The F10 function keyId.
        F10 = 121,
        //
        // Summary:
        //     The F11 function keyId.
        F11 = 122,
        //
        // Summary:
        //     The F12 function keyId.
        F12 = 123,
        //
        // Summary:
        //     The F13 function keyId.
        F13 = 124,
        //
        // Summary:
        //     The F14 function keyId.
        F14 = 125,
        //
        // Summary:
        //     The F15 function keyId.
        F15 = 126,
        //
        // Summary:
        //     The F16 function keyId.
        F16 = 0x7F,
        //
        // Summary:
        //     The F17 function keyId.
        F17 = 0x80,
        //
        // Summary:
        //     The F18 function keyId.
        F18 = 129,
        //
        // Summary:
        //     The F19 function keyId.
        F19 = 130,
        //
        // Summary:
        //     The F20 function keyId.
        F20 = 131,
        //
        // Summary:
        //     The F21 function keyId.
        F21 = 132,
        //
        // Summary:
        //     The F22 function keyId.
        F22 = 133,
        //
        // Summary:
        //     The F23 function keyId.
        F23 = 134,
        //
        // Summary:
        //     The F24 function keyId.
        F24 = 135,
        //
        // Summary:
        //     The navigation up button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationView = 136,
        //
        // Summary:
        //     The navigation menu button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationMenu = 137,
        //
        // Summary:
        //     The navigation up button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationUp = 138,
        //
        // Summary:
        //     The navigation down button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationDown = 139,
        //
        // Summary:
        //     The navigation left button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationLeft = 140,
        //
        // Summary:
        //     The navigation right button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationRight = 141,
        //
        // Summary:
        //     The navigation accept button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationAccept = 142,
        //
        // Summary:
        //     The navigation cancel button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationCancel = 143,
        //
        // Summary:
        //     The Num Lock keyId.
        NumberKeyLock = 144,
        //
        // Summary:
        //     The Scroll Lock (ScrLk) keyId.
        Scroll = 145,
        //
        // Summary:
        //     The left Shift keyId.
        LeftShift = 160,
        //
        // Summary:
        //     The right Shift keyId.
        RightShift = 161,
        //
        // Summary:
        //     The left Ctrl keyId.
        LeftControl = 162,
        //
        // Summary:
        //     The right Ctrl keyId.
        RightControl = 163,
        //
        // Summary:
        //     The left menu keyId.
        LeftMenu = 164,
        //
        // Summary:
        //     The right menu keyId.
        RightMenu = 165,
        //
        // Summary:
        //     The go back keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoBack = 166,
        //
        // Summary:
        //     The go forward keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoForward = 167,
        //
        // Summary:
        //     The refresh keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Refresh = 168,
        //
        // Summary:
        //     The stop keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Stop = 169,
        //
        // Summary:
        //     The search keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Search = 170,
        //
        // Summary:
        //     The favorites keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Favorites = 171,
        //
        // Summary:
        //     The go home keyId.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoHome = 172,
        //
        // Summary:
        //     The gamepad A button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadA = 195,
        //
        // Summary:
        //     The gamepad B button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadB = 196,
        //
        // Summary:
        //     The gamepad X button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadX = 197,
        //
        // Summary:
        //     The gamepad Y button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadY = 198,
        //
        // Summary:
        //     The gamepad right shoulder.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightShoulder = 199,
        //
        // Summary:
        //     The gamepad left shoulder.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftShoulder = 200,
        //
        // Summary:
        //     The gamepad left trigger.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftTrigger = 201,
        //
        // Summary:
        //     The gamepad right trigger.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightTrigger = 202,
        //
        // Summary:
        //     The gamepad d-pad up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadUp = 203,
        //
        // Summary:
        //     The gamepad d-pad down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadDown = 204,
        //
        // Summary:
        //     The gamepad d-pad left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadLeft = 205,
        //
        // Summary:
        //     The gamepad d-pad right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadRight = 206,
        //
        // Summary:
        //     The gamepad menu button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadMenu = 207,
        //
        // Summary:
        //     The gamepad view button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadView = 208,
        //
        // Summary:
        //     The gamepad left thumbstick button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickButton = 209,
        //
        // Summary:
        //     The gamepad right thumbstick button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickButton = 210,
        //
        // Summary:
        //     The gamepad left thumbstick up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickUp = 211,
        //
        // Summary:
        //     The gamepad left thumbstick down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickDown = 212,
        //
        // Summary:
        //     The gamepad left thumbstick right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickRight = 213,
        //
        // Summary:
        //     The gamepad left thumbstick left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickLeft = 214,
        //
        // Summary:
        //     The gamepad right thumbstick up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickUp = 215,
        //
        // Summary:
        //     The gamepad right thumbstick down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickDown = 216,
        //
        // Summary:
        //     The gamepad right thumbstick right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickRight = 217,
        //
        // Summary:
        //     The gamepad right thumbstick left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickLeft = 218
    }
    public enum KeyAction
    {
        KeyDown,
        KeyUp
    }

    public sealed class KeyboardKey
    {        
        private enum KeyActionCode : uint
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,

            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105
        }

        public KeyCode KeyCode { get; }
        public KeyId KeyId { get; }
        public bool IsPressed { get; private set; } = false;

        public KeyboardKey(KeyCode keyCode, KeyId keyId)
        {
            KeyCode = keyCode;
            KeyId = keyId;
        }

        public static uint GetKeyScanCode(KeyCode keyCode)
        {
            MapVirtualKeyMapTypes mapType = MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC;
            uint ScanCode = MapVirtualKeyM((uint)keyCode, mapType);
            return ScanCode;
        }
        public static bool IsExtendedKey(KeyCode keyCode)
        {
            List<KeyCode> extendedKeys = new() {
                // Control keys
                KeyCode.VK_RMENU,
                KeyCode.VK_RCONTROL,
                // Navigation keys
                KeyCode.VK_LEFT,
                KeyCode.VK_RIGHT,
                KeyCode.VK_UP,
                KeyCode.VK_DOWN,
                KeyCode.VK_INSERT,
                KeyCode.VK_DELETE,
                KeyCode.VK_HOME,
                KeyCode.VK_END,
                KeyCode.VK_PRIOR,
                KeyCode.VK_NEXT,
                // Other keys
                KeyCode.VK_DIVIDE,
                KeyCode.VK_NUMLOCK
            };

            if (!extendedKeys.Contains(keyCode)) return false;
            return true;
        }
        public static bool IsSystemKey(KeyCode keyCode)
        {
            List<KeyCode> systemKeys = new() {
                // Control keys
                KeyCode.VK_MENU,
                KeyCode.VK_LMENU,
                KeyCode.VK_RMENU,
                // Function keys
                KeyCode.VK_F10,
            };

            if (!systemKeys.Contains(keyCode)) return false;
            return true;
        }
        private static IntPtr GenerateLPARAM(KeyCode keyCode, ushort repeatCount, bool transitionState, bool previousState, bool contextCode)
        {
            uint ScanCode = GetKeyScanCode(keyCode);
            bool isExtended = IsExtendedKey(keyCode);

            return (IntPtr)(
                (Convert.ToInt64(transitionState) << 31) |
                (Convert.ToInt64(previousState) << 30) |
                (Convert.ToInt64(contextCode) << 29) |
                (Convert.ToInt64(isExtended) << 24) |
                (ScanCode << 16) |
                (repeatCount));
        }
        private static IntPtr GenerateKeyDownLPARAM(KeyCode keyCode, bool previousState)
        {
            // Number of keyCode-strokes to send AT THE SAME TIME.
            // If set to e.g. 20, the action will resoult will be the same as pressing the keyCode 20x separately
            const ushort repeatCount = 1; 
            const bool transitionState = false;
            const bool contextCode = false;
            return GenerateLPARAM(keyCode, repeatCount, transitionState, previousState, contextCode);
        }
        private static IntPtr GenerateKeyUpLPARAM(KeyCode keyCode)
        {
            // Number of keyCode-strokes to send AT THE SAME TIME.
            // If set to e.g. 20, the action will resoult will be the same as pressing the keyCode 20x separately
            const ushort repeatCount = 1;
            const bool transitionState = true;
            const bool previousState = true;
            const bool contextCode = false;
            return GenerateLPARAM(keyCode, repeatCount, transitionState, previousState, contextCode);
        }

        private uint GenerateMsgParam(KeyAction keyAction)
        {
            bool isSystemKey = IsSystemKey(KeyCode);
            uint? msgParam = null;
            if (keyAction == KeyAction.KeyDown && !isSystemKey) msgParam = (uint)KeyActionCode.WM_KEYDOWN;
            if (keyAction == KeyAction.KeyDown && isSystemKey) msgParam = (uint)KeyActionCode.WM_SYSKEYDOWN;
            if (keyAction == KeyAction.KeyUp && !isSystemKey) msgParam = (uint)KeyActionCode.WM_KEYUP;
            if (keyAction == KeyAction.KeyUp && isSystemKey) msgParam = (uint)KeyActionCode.WM_SYSKEYUP;
            if (msgParam == null) throw new NullReferenceException(nameof(msgParam));

            return (uint)msgParam;
        }
        private IntPtr GenerateLPARAM(KeyAction keyAction)
        {
            IntPtr? lParam = null;
            if (keyAction == KeyAction.KeyDown) lParam = GenerateKeyDownLPARAM(KeyCode, IsPressed);
            if (keyAction == KeyAction.KeyUp) lParam = GenerateKeyUpLPARAM(KeyCode);
            if (lParam == null) throw new NullReferenceException(nameof(lParam));

            return (IntPtr)lParam;
        }

        public void Post(IntPtr windowHandle, KeyAction keyAction)
        {
            uint msgParam = GenerateMsgParam(keyAction);
            IntPtr lParam = GenerateLPARAM(keyAction);
            IntPtr keyCode = (IntPtr)KeyCode;
            PostMessageM(windowHandle, msgParam, keyCode, lParam);

            if (keyAction == KeyAction.KeyDown) IsPressed = true;
            else IsPressed = false;
        }
        public void Send(IntPtr windowHandle, KeyAction keyAction)
        {
            uint msgParam = GenerateMsgParam(keyAction);
            IntPtr lParam = GenerateLPARAM(keyAction);
            IntPtr keyCode = (IntPtr)KeyCode;
            SendMessageM(windowHandle, msgParam, keyCode, lParam);

            if (keyAction == KeyAction.KeyDown) IsPressed = true;
            else IsPressed = false;
        }
    }
}
