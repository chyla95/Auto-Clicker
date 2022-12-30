using System.Runtime.InteropServices;

namespace PInvokeWrapper.Window
{
    public static partial class Window
    {
        /// <summary>
        /// Places a message in the message queue associated with the thread that created the specified window.
        /// Returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="Msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>If the function fails, the return value is zero. 
        /// To get extended error information, call GetLastError. 
        /// GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the limit is hit.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage([In, Optional] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

        /// <summary>
        /// Calls the window procedure and sends the specified message.
        /// Does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="Msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage([In] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

        /// <summary>
        /// Places a message in the message queue associated with the thread that created the specified window.
        /// Returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="message">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        public static void PostMessageM(IntPtr windowHandle, uint message, IntPtr wParam, IntPtr lParam)
        {
            PostMessage(windowHandle, message, wParam, lParam);
        }

        /// <summary>
        /// Calls the window procedure and sends the specified message.
        /// Does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="windowHandle">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="message">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        public static void SendMessageM(IntPtr windowHandle, uint message, IntPtr wParam, IntPtr lParam)
        {
            SendMessage(windowHandle, message, wParam, lParam);
        }
    }
}
