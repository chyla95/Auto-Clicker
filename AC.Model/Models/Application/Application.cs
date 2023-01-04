using System.Diagnostics;
using PeripheralDeviceEmulator.Keyboard;

namespace AC.Model.Models.Application
{
    public class Application : ModelBase
    {
        private readonly Process _process;
        private readonly IKeyboardEmulator _keyboardEmulator;

        public bool IsSelected { get; set; }
        public int Id
        {
            get
            {
                return _process.Id;
            }
        }
        public string Name
        {
            get
            {
                return _process.ProcessName;
            }
        }
        public Window? Window
        {
            get
            {
                IntPtr windowHandle = _process.MainWindowHandle;
                if (windowHandle == IntPtr.Zero) return null;

                return new Window(windowHandle, _keyboardEmulator);
            }
        }

        public Application(Process process, IKeyboardEmulator keyboardEmulator)
        {
            _process = process;
            _keyboardEmulator = keyboardEmulator;
        }
    }
}
