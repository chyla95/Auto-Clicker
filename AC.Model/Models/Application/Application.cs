using System.Diagnostics;
using AC.ProcessManager.Core;

namespace AC.Model.Models.Application
{
    public class Application
    {
        private readonly Process _process;
        private readonly IKeyboardEmulator _keyboardEmulator;

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
                IntPtr windowHandle = GetWindowHandle();
                if (windowHandle == IntPtr.Zero) return null;

                return new Window(windowHandle, _keyboardEmulator);
            }
        }

        public Application(Process process, IKeyboardEmulator keyboardEmulator)
        {
            _process = process;
            _keyboardEmulator = keyboardEmulator;
        }

        private IntPtr GetWindowHandle()
        {
            IntPtr windowHandle = _process.MainWindowHandle;
            return windowHandle;
        }
    }
}
