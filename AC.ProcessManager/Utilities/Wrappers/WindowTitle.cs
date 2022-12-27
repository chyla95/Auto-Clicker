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

        public static void SetTitle(IntPtr windowHandle, string title)
        {
            SetWindowText(windowHandle, title);
        }
        public static string GetTitle(IntPtr windowHandle)
        {
            int titleLength = GetWindowTextLength(windowHandle);
            StringBuilder title = new(titleLength + 1);
            GetWindowText(windowHandle, title, (uint)title.Capacity);
            return title.ToString();
        }
    }
}
