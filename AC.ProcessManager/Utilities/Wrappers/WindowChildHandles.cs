using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace AC.ProcessManager.Utilities.Wrappers
{
    internal static partial class Window
    {
        /// <summary>
        /// Delegate for the EnumChildWindows method
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="lParam">Caller-defined variable; a lParam to the passed windowHandles</param>
        /// <returns>True to continue enumerating, false to bail.</returns>
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows([In, Optional] IntPtr hWndParent, [In] EnumWindowsProc lpEnumFunc, [In] IntPtr lParam);

        /// <summary>
        /// Returns a windowHandles of child windows
        /// </summary>
        /// <param name="windowHandle">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static IEnumerable<IntPtr> GetWindowChildHandles(IntPtr windowHandle)
        {
            IEnumerable<IntPtr> windowHandles = new List<IntPtr>();
            GCHandle managedWindowHandles = GCHandle.Alloc(windowHandles);
            try
            {
                EnumWindowsProc callback = new(EnumWindowCallback);
                EnumChildWindows(windowHandle, callback, GCHandle.ToIntPtr(managedWindowHandles));
            }
            catch (Exception) { }
            if (managedWindowHandles.IsAllocated) managedWindowHandles.Free();

            return windowHandles;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="hWnd">Handle of the next window</param>
        /// <param name="lParam">Pointer to a GCHandle that holds a reference to the windowHandles to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindowCallback(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gch = GCHandle.FromIntPtr(lParam);
            List<IntPtr>? windowHandles = (List<IntPtr>?)gch.Target;
            if (windowHandles == null) throw new InvalidCastException("GCHandle Target cast failed!");

            windowHandles.Add(hWnd);

            return true;
        }
    }
}
