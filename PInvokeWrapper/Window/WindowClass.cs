using System.Runtime.InteropServices;
using System.Text;

namespace PInvokeWrapper.Window
{
    public static partial class Window
    {
        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="lpClassName">The class name string.</param>
        /// <param name="nMaxCount">The length of the lpClassName buffer, in characters. The buffer must be large enough to include the terminating null character; 
        /// otherwise, the class name string is truncated to nMaxCount-1 characters.</param>
        /// <returns>If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError function.</returns>
        [DllImport("user32.dll", BestFitMapping = false)]
        private static extern int GetClassName([In] IntPtr hWnd, [Out] StringBuilder lpClassName, [In] int nMaxCount);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="windowHandle">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <returns>The class name.</returns>
        public static string GetClassNameM(IntPtr windowHandle)
        {
            StringBuilder ClassName = new(256); // Pre-allocate 256 characters (maximum class name length).
            _ = GetClassName(windowHandle, ClassName, ClassName.Capacity);

            return ClassName.ToString();
        }
    }
}
