using System.Runtime.InteropServices;

namespace PInvokeWrapper.Window
{
    public static partial class Window
    {
        /// <summary>
        /// An application-defined callback function for EnumChildWindows method.
        /// </summary>
        /// <param name="hWnd">A handle to a top-level window.</param>
        /// <param name="lParam">The application-defined value; a lParam to the passed windowHandles</param>
        /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, 
        /// in turn, to an application-defined callback function. 
        /// EnumChildWindows continues until the last child window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="hWndParent">A handle to the parent window whose child windows are to be enumerated. If this parameter is NULL, this function is equivalent to EnumWindows.</param>
        /// <param name="lpEnumFunc">A pointer to an application-defined callback function. For more information, see EnumChildProc.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>The return value is not used.</returns>
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows([In, Optional] IntPtr hWndParent, [In] EnumWindowsProc lpEnumFunc, [In] IntPtr lParam);

        /// <summary>
        /// Retrives a list of pointers to window's children.
        /// </summary>
        /// <param name="windowHandle">A handle to the parent window.</param>
        /// <returns>A List of pointers to window's children.</returns>
        public static IEnumerable<IntPtr> GetChildWindowsHandlesM(IntPtr windowHandle)
        {
            IEnumerable<IntPtr> windowHandles = new List<IntPtr>();
            GCHandle managedWindowHandles = GCHandle.Alloc(windowHandles);
            try
            {
                EnumWindowsProc callback = new(EnumCallback);
                EnumChildWindows(windowHandle, callback, GCHandle.ToIntPtr(managedWindowHandles));
            }
            catch (Exception) { }
            if (managedWindowHandles.IsAllocated) managedWindowHandles.Free();

            return windowHandles;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="hWnd">Handle of the next window.</param>
        /// <param name="lParam">Pointer to a GCHandle that holds a reference to the windowHandles to fill.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
        private static bool EnumCallback(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gch = GCHandle.FromIntPtr(lParam);
            List<IntPtr>? windowHandles = (List<IntPtr>?)gch.Target;
            if (windowHandles == null) throw new InvalidCastException("GCHandle Target cast failed!");

            windowHandles.Add(hWnd);

            return true;
        }
    }
}
