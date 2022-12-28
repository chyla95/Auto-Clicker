using System.Runtime.InteropServices;

namespace AC.ProcessManager.Utilities.Wrappers
{
    internal static partial class Window
    {
        // Places a message in the message queue associated with the thread that created the specified window.
        // Returns without waiting for the thread to process the message.
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage([In, Optional] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);
        // Calls the window procedure and sends the specified message.
        // Does not return until the window procedure has processed the message.
        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage([In] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

        public static void PostMessageM(IntPtr windowHandle, uint message, IntPtr wParam, IntPtr lParam)
        {
            PostMessage(windowHandle, message, wParam, lParam);
        }

        public static void SendMessageM(IntPtr windowHandle, uint message, IntPtr wParam, IntPtr lParam)
        {
            SendMessage(windowHandle, message, wParam, lParam);
        }
    }
}
