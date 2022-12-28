using System.Runtime.InteropServices;
using System.Text;

namespace AC.ProcessManager.Utilities.Wrappers
{
    internal static partial class Window
    {
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern bool SetWindowText([In] IntPtr hWnd, [In] string lpString);
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength([In] IntPtr hWnd);
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern int GetWindowText([In] IntPtr hWnd, [Out] StringBuilder lpString, [In] uint nMaxCount);

        public static void SetTextM(IntPtr windowHandle, string text)
        {
            SetWindowText(windowHandle, text);
        }
        public static string GetTextM(IntPtr windowHandle)
        {
            int textLength = GetWindowTextLength(windowHandle);
            StringBuilder text = new(textLength + 1);
            _ = GetWindowText(windowHandle, text, (uint)text.Capacity);
            return text.ToString();
        }
    }
}
