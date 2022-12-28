﻿namespace AC.ProcessManager.Core
{
    public class Window
    {
        public IntPtr Handle { get; private set; }
        public string Text
        {
            get
            {
                string value = Utilities.Wrappers.Window.GetTextM(Handle);
                return value;
            }
            set
            {
                Utilities.Wrappers.Window.SetTextM(Handle, value);
            }
        }
        public string Class
        {
            get
            {
                string value = Utilities.Wrappers.Window.GetClassNameM(Handle);
                return value;
            }
        }

        public Window(IntPtr handle)
        {
            Handle = handle;
        }

        public IEnumerable<Window> GetChildWindows()
        {
            IEnumerable<IntPtr> childHandles = Utilities.Wrappers.Window.GetChildWindowsHandlesM(Handle);
            List<Window> childWindows = new();

            foreach (IntPtr childHandle in childHandles)
            {
                Window childWindow = new(childHandle);
                childWindows.Add(childWindow);
            }

            return childWindows;
        }

        public enum Keys
        {
            //0 key
            KEY_0 = 0x30,
            //1 key
            KEY_1 = 0x31,
            //2 key
            KEY_2 = 0x32,
            //3 key
            KEY_3 = 0x33,
            //4 key
            KEY_4 = 0x34,
            //5 key
            KEY_5 = 0x35,
            //6 key
            KEY_6 = 0x36,
            //7 key
            KEY_7 = 0x37,
            //8 key
            KEY_8 = 0x38,
            //9 key
            KEY_9 = 0x39,
            // - key
            KEY_MINUS = 0xBD,
            // + key
            KEY_PLUS = 0xBB,
            //A key
            KEY_A = 0x41,
            //B key
            KEY_B = 0x42,
            //C key
            KEY_C = 0x43,
            //D key
            KEY_D = 0x44,
            //E key
            KEY_E = 0x45,
            //F key
            KEY_F = 0x46,
            //G key
            KEY_G = 0x47,
            //H key
            KEY_H = 0x48,
            //I key
            KEY_I = 0x49,
            //J key
            KEY_J = 0x4A,
            //L key
            KEY_L = 0x4C,
            //K key
            KEY_K = 0x4B,
            //M key
            KEY_M = 0x4D,
            //N key
            KEY_N = 0x4E,
            //O key
            KEY_O = 0x4F,
            //P key
            KEY_P = 0x50,
            //Q key
            KEY_Q = 0x51,
            //R key
            KEY_R = 0x52,
            //S key
            KEY_S = 0x53,
            //T key
            KEY_T = 0x54,
            //U key
            KEY_U = 0x55,
            //V key
            KEY_V = 0x56,
            //W key
            KEY_W = 0x57,
            //X key
            KEY_X = 0x58,
            //Y key
            KEY_Y = 0x59,
            //Z key
            KEY_Z = 0x5A,
            //Left mouse button
            KEY_LBUTTON = 0x01,
            //Right mouse button
            KEY_RBUTTON = 0x02,
            //Control-break processing
            KEY_CANCEL = 0x03,
            //Middle mouse button (three-button mouse)
            KEY_MBUTTON = 0x04,
            //BACKSPACE key  
            KEY_BACK = 0x08,
            //TAB key
            KEY_TAB = 0x09,
            //CLEAR key
            KEY_CLEAR = 0x0C,
            //ENTER key
            KEY_RETURN = 0x0D,
            //SHIFT key
            KEY_SHIFT = 0x10,
            //CTRL key
            KEY_CONTROL = 0x11,
            //ALT key
            KEY_MENU = 0x12,
            //PAUSE key
            KEY_PAUSE = 0x13,
            //CAPS LOCK key
            KEY_CAPITAL = 0x14,
            //ESC key
            KEY_ESCAPE = 0x1B,
            //SPACEBAR
            KEY_SPACE = 0x20,
            //PAGE UP key
            KEY_PRIOR = 0x21,
            //PAGE DOWN key
            KEY_NEXT = 0x22,
            //END key
            KEY_END = 0x23,
            //HOME key
            KEY_HOME = 0x24,
            //LEFT ARROW key
            KEY_LEFT = 0x25,
            //UP ARROW key
            KEY_UP = 0x26,
            //RIGHT ARROW key
            KEY_RIGHT = 0x27,
            //DOWN ARROW key
            KEY_DOWN = 0x28,
            //SELECT key
            KEY_SELECT = 0x29,
            //PRINT key
            KEY_PRINT = 0x2A,
            //EXECUTE key
            KEY_EXECUTE = 0x2B,
            //PRINT SCREEN key
            KEY_SNAPSHOT = 0x2C,
            //INS key
            KEY_INSERT = 0x2D,
            //DEL key
            KEY_DELETE = 0x2E,
            //HELP key
            KEY_HELP = 0x2F,
            //Numeric keypad 0 key
            KEY_NUMPAD0 = 0x60,
            //Numeric keypad 1 key
            KEY_NUMPAD1 = 0x61,
            //Numeric keypad 2 key
            KEY_NUMPAD2 = 0x62,
            //Numeric keypad 3 key  
            KEY_NUMPAD3 = 0x63,
            //Numeric keypad 4 key  
            KEY_NUMPAD4 = 0x64,
            //Numeric keypad 5 key  
            KEY_NUMPAD5 = 0x65,
            //Numeric keypad 6 key  
            KEY_NUMPAD6 = 0x66,
            //Numeric keypad 7 key
            KEY_NUMPAD7 = 0x67,
            //Numeric keypad 8 key  
            KEY_NUMPAD8 = 0x68,
            //Numeric keypad 9 key  
            KEY_NUMPAD9 = 0x69,
            //Separator key
            KEY_SEPARATOR = 0x6C,
            //Subtract key
            KEY_SUBTRACT = 0x6D,
            //Decimal key
            KEY_DECIMAL = 0x6E,
            //Divide key
            KEY_DIVIDE = 0x6F,
            //F1 key
            KEY_F1 = 0x70,
            //F2 key
            KEY_F2 = 0x71,
            //F3 key
            KEY_F3 = 0x72,
            //F4 key
            KEY_F4 = 0x73,
            //F5 key
            KEY_F5 = 0x74,
            //F6 key
            KEY_F6 = 0x75,
            //F7 key
            KEY_F7 = 0x76,
            //F8 key
            KEY_F8 = 0x77,
            //F9 key
            KEY_F9 = 0x78,
            //F10 key
            KEY_F10 = 0x79,
            //F11 key
            KEY_F11 = 0x7A,
            //F12 key
            KEY_F12 = 0x7B,
            //SCROLL LOCK key
            KEY_SCROLL = 0x91,
            //Left SHIFT key
            KEY_LSHIFT = 0xA0,
            //Right SHIFT key
            KEY_RSHIFT = 0xA1,
            //Left CONTROL key
            KEY_LCONTROL = 0xA2,
            //Right CONTROL key
            KEY_RCONTROL = 0xA3,
            //Left MENU key
            KEY_LMENU = 0xA4,
            //Right MENU key
            KEY_RMENU = 0xA5,
            //, key
            KEY_COMMA = 0xBC,
            //. key
            KEY_PERIOD = 0xBE,
            //Play key
            KEY_PLAY = 0xFA,
            //Zoom key
            KEY_ZOOM = 0xFB,
            //Null
            NULL = 0x0,
        }
        public enum KeyActions
        {
            KeyDown = 0x100,
            KeyUp = 0x0101
        }
        public void SendKey()
        {
            Utilities.Wrappers.Window.PostMessageM(Handle, (uint)KeyActions.KeyDown, (IntPtr)Keys.KEY_UP, IntPtr.Zero);
            Thread.Sleep(1122);
            Utilities.Wrappers.Window.PostMessageM(Handle, (uint)KeyActions.KeyUp, (IntPtr)Keys.KEY_UP, IntPtr.Zero);
        }
    }
}
