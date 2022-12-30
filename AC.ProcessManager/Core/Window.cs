using System.Diagnostics;
using System.Runtime.InteropServices;
using static AC.ProcessManager.Utilities.Wrappers.Keyboard;

namespace AC.ProcessManager.Core
{
    public class Window
    {
        private readonly Keyboard _keyboard;

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

        public Window(IntPtr handle, Keyboard keyboard)
        {
            Handle = handle;
            _keyboard = keyboard;
        }

        public IEnumerable<Window> GetChildWindows()
        {
            IEnumerable<IntPtr> childHandles = Utilities.Wrappers.Window.GetChildWindowsHandlesM(Handle);
            List<Window> childWindows = new();

            foreach (IntPtr childHandle in childHandles)
            {
                Window childWindow = new(childHandle, _keyboard);
                childWindows.Add(childWindow);
            }

            return childWindows;
        }

        /// <summary>
        /// Places a message in the message queue associated with the thread that created the specified window.
        /// Returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="keyId">ID of the key to press</param>
        /// <param name="keyAction">Key action to execute</param>
        public void PostKey(KeyId keyId, KeyAction keyAction)
        {
            KeyboardKey key = _keyboard.GetKey(keyId);
            key.Post(Handle, keyAction);
        }

        /// <summary>
        /// Calls the window procedure and sends the specified message.
        /// Does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="keyId">ID of the key to press</param>
        /// <param name="keyAction">Key action to execute</param>
        public void SendKey(KeyId keyId, KeyAction keyAction)
        {
            KeyboardKey key = _keyboard.GetKey(keyId);
            key.Send(Handle, keyAction);
        }
    }
}
