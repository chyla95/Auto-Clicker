using System.Runtime.InteropServices;
using System.Text;

namespace PInvokeWrapper.Window
{
    public static partial class Window
    {
        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. 
        /// Text of controls from another applications cannot be changed!.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The new title or control text.</param>
        /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern bool SetWindowText([In] IntPtr hWnd, [In] string lpString);

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). 
        /// If the specified window is a control, the function retrieves the length of the text within the control. 
        /// Text of controls from another applications cannot be retrieved!
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the text. 
        /// Function failure is indicated by a return value of zero and a GetLastError result that is nonzero.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength([In] IntPtr hWnd);

        /// <summary>
        /// Retrieves text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// Text of controls from another applications cannot be retrieved!.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="nMaxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, 
        /// not including the terminating null character. If the window has no title bar or text, if the title bar is empty, 
        /// or if the window or control handle is invalid, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern int GetWindowText([In] IntPtr hWnd, [Out] StringBuilder lpString, [In] uint nMaxCount);

        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. 
        /// Text of controls from another applications cannot be changed!.
        /// </summary>
        /// <param name="windowHandle">A handle to the window or control whose text is to be changed.</param>
        /// <param name="text">The new title or control text.</param>
        public static void SetTextM(IntPtr windowHandle, string text)
        {
            SetWindowText(windowHandle, text);
        }

        /// <summary>
        /// Retrieves text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// Text of controls from another applications cannot be retrieved!.
        /// </summary>
        /// <param name="windowHandle">A handle to the window or control whose text is to be changed.</param>
        /// <returns>Returns a value of the given window's (or control) title (or text).</returns>
        public static string GetTextM(IntPtr windowHandle)
        {
            int textLength = GetWindowTextLength(windowHandle);
            StringBuilder text = new(textLength + 1);
            _ = GetWindowText(windowHandle, text, (uint)text.Capacity);
            return text.ToString();
        }
    }
}
