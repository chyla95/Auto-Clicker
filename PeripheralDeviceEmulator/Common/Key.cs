using PeripheralDeviceEmulator.Constants;
using static PInvokeWrapper.Keyboard.Keyboard;
using static PInvokeWrapper.Window.Window;

namespace PeripheralDeviceEmulator.Common
{
    public class Key : IKey
    {
        public KeyCode Code { get; }
        public bool IsPressed { get; private set; }

        public Key(KeyCode code)
        {
            Code = code;
        }

        protected uint GetScanCode()
        {
            MapVirtualKeyMapTypes mapType = MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC;
            uint? ScanCode = MapVirtualKeyM((uint)Code, mapType);
            if(ScanCode == null) throw new NullReferenceException(nameof(ScanCode));

            return (uint)ScanCode;
        }
        protected bool IsExtendedKey()
        {
            List<KeyCode> extendedKeys = new() {
                KeyCode.RightMenu,
                KeyCode.RightControl,
                KeyCode.Up,
                KeyCode.Down,
                KeyCode.Left,
                KeyCode.Right,
                KeyCode.Insert,
                KeyCode.Delete,
                KeyCode.Home,
                KeyCode.End,
                KeyCode.PageUp,
                KeyCode.PageDown,
                KeyCode.Divide,
                KeyCode.NumberKeyLock
            };

            if (!extendedKeys.Contains(Code)) return false;
            return true;
        }
        protected bool IsSystemKey()
        {
            List<KeyCode> systemKeys = new() {
                KeyCode.Menu,
                KeyCode.LeftMenu,
                KeyCode.RightMenu,
                KeyCode.F10,
            };

            if (!systemKeys.Contains(Code)) return false;
            return true;
        }

        private static IntPtr GenerateLparam(ushort repeatCount, ushort transitionState, ushort previousState, ushort contextCode, ushort scanCode, ushort isExtended)
        {
            return (IntPtr)(
                (transitionState << 31) |
                (previousState << 30) |
                (contextCode << 29) |
                (isExtended << 24) |
                (scanCode << 16) |
                (repeatCount));
        }
        private IntPtr GenerateKeyDownLparam()
        {
            // Number of keyCode-strokes to send AT THE SAME TIME.
            // If set to e.g. 20, the action will resoult will be the same as pressing the keyCode 20x separately
            const ushort repeatCount = 1;
            const ushort transitionState = 0;
            const ushort contextCode = 0;
            ushort previousState = Convert.ToUInt16(IsPressed);
            ushort ScanCode = Convert.ToUInt16(GetScanCode());
            ushort isExtended = Convert.ToUInt16(IsExtendedKey());

            return GenerateLparam(repeatCount, transitionState, previousState, contextCode, ScanCode, isExtended);
        }
        private IntPtr GenerateKeyUpLparam()
        {
            // Number of keyCode-strokes to send AT THE SAME TIME.
            // If set to e.g. 20, the action will resoult will be the same as pressing the keyCode 20x separately
            const ushort repeatCount = 1;
            const ushort transitionState = 1;
            const ushort contextCode = 0;
            const ushort previousState = 1;
            ushort ScanCode = Convert.ToUInt16(GetScanCode());
            ushort isExtended = Convert.ToUInt16(IsExtendedKey());
            return GenerateLparam(repeatCount, transitionState, previousState, contextCode, ScanCode, isExtended);
        }

        private IntPtr GenerateLparam(KeyAction keyAction)
        {
            IntPtr? lParam = null;
            if (keyAction == KeyAction.KeyDown) lParam = GenerateKeyDownLparam();
            if (keyAction == KeyAction.KeyUp) lParam = GenerateKeyUpLparam();
            if (lParam == null) throw new NullReferenceException(nameof(lParam));

            return (IntPtr)lParam;
        }
        private uint GenerateMsgParam(KeyAction keyAction)
        {
            bool isSystemKey = IsSystemKey();
            uint? msgParam = null;
            if (keyAction == KeyAction.KeyDown && !isSystemKey) msgParam = (uint)WindowsMessages.WM_KEYDOWN;
            if (keyAction == KeyAction.KeyDown && isSystemKey) msgParam = (uint)WindowsMessages.WM_SYSKEYDOWN;
            if (keyAction == KeyAction.KeyUp && !isSystemKey) msgParam = (uint)WindowsMessages.WM_KEYUP;
            if (keyAction == KeyAction.KeyUp && isSystemKey) msgParam = (uint)WindowsMessages.WM_SYSKEYUP;
            if (msgParam == null) throw new NullReferenceException(nameof(msgParam));

            return (uint)msgParam;
        }

        public void Post(IntPtr windowHandle, KeyAction keyAction)
        {
            uint msgParam = GenerateMsgParam(keyAction);
            IntPtr lParam = GenerateLparam(keyAction);
            IntPtr keyCode = (IntPtr)Code;
            PostMessageM(windowHandle, msgParam, keyCode, lParam);

            if (keyAction == KeyAction.KeyDown) IsPressed = true;
            else IsPressed = false;
        }
        public void Send(IntPtr windowHandle, KeyAction keyAction)
        {
            uint msgParam = GenerateMsgParam(keyAction);
            IntPtr lParam = GenerateLparam(keyAction);
            IntPtr keyCode = (IntPtr)Code;
            SendMessageM(windowHandle, msgParam, keyCode, lParam);

            if (keyAction == KeyAction.KeyDown) IsPressed = true;
            else IsPressed = false;
        }
    }
}
