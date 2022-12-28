using System.Runtime.InteropServices;
using System.Text;

namespace AC.ProcessManager.Utilities.Wrappers
{
    internal static partial class Window
    {
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern int GetClassName([In] IntPtr hWnd, [Out] StringBuilder lpClassName, [In] int nMaxCount);

        private static string GetWindowClassName(IntPtr hWnd)
        {
            StringBuilder ClassName = new(256); // Pre-allocate 256 characters (maximum class name length).
            _ = GetClassName(hWnd, ClassName, ClassName.Capacity);

            return ClassName.ToString();
        }
    }
}
