using System.Collections.ObjectModel;
using PeripheralDeviceEmulator.Common;
using PeripheralDeviceEmulator.Constants;
using PeripheralDeviceEmulator.Keyboard;
using static PInvokeWrapper.Window.Window;

namespace AC.Model.Models.Application
{
    public class Window : ModelBase
    {
        private readonly IntPtr _handle;
        private readonly IKeyboardEmulator _keyboardEmulator;

        public IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }
        public string Title
        {
            get
            {
                string value = GetTextM(Handle);
                return value;
            }
            set
            {
                SetTextM(Handle, value);
            }
        }
        public ObservableCollection<Window> ChildWindows { get; }

        public Window(IntPtr handle, IKeyboardEmulator keyboardEmulator)
        {
            _handle = handle;
            _keyboardEmulator = keyboardEmulator;

            ChildWindows = new ObservableCollection<Window>(GetChildWindows());
        }

        private IEnumerable<Window> GetChildWindows()
        {
            IEnumerable<IntPtr> childHandles = GetChildWindowsHandlesM(Handle);
            List<Window> childWindows = new();

            foreach (IntPtr childHandle in childHandles)
            {
                Window childWindow = new(childHandle, _keyboardEmulator);
                childWindows.Add(childWindow);
            }

            return childWindows;
        }

        public void PostKey(KeyCode keyCode, KeyAction keyAction)
        {
            IKey? key = _keyboardEmulator.GetKey(keyCode);
            if (key == null) throw new Exception("Unsupported key!");

            key.Post(Handle, keyAction);
        }
        public void SendKey(KeyCode keyCode, KeyAction keyAction)
        {
            IKey? key = _keyboardEmulator.GetKey(keyCode);
            if (key == null) throw new Exception("Unsupported key!");

            key.Send(Handle, keyAction);
        }

        public void PressKey(KeyCode keyCode, KeyAction keyAction, KeyPressMethod keyInjectionMethod)
        {
            IKey? key = _keyboardEmulator.GetKey(keyCode);
            if (key == null) throw new Exception("Unsupported key!");

            switch (keyInjectionMethod)
            {
                case KeyPressMethod.Post:
                    key.Post(Handle, keyAction);
                    break;
                case KeyPressMethod.Send:
                    key.Send(Handle, keyAction);
                    break;
            }
        }
    }

    public enum KeyPressMethod
    {
        Post,
        Send
    }
}
