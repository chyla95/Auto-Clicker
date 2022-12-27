using System.Runtime.InteropServices;

namespace AC.ProcessManager.Utilities.Wrappers
{
    internal static partial class Window
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx([In] ref FLASHWINFO pfwi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure in bytes.
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The Flash Status.
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// The number of times to Flash the window.
            /// </summary>
            public uint uCount;
            /// <summary>
            /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
            /// </summary>
            public uint dwTimeout;

            public FLASHWINFO(IntPtr windowHandle, uint flags, uint flashCount, uint timeout)
            {
                cbSize = (uint)Marshal.SizeOf<FLASHWINFO>();
                hwnd = windowHandle;
                dwFlags = flags;
                uCount = flashCount;
                dwTimeout = timeout;
            }
        }

        /// <summary>
        /// Stop flashing. The system restores the window to its original stae.
        /// </summary>
        private const uint FLASHW_STOP = 0;
        /// <summary>
        /// Flash the window caption.
        /// </summary>
        private const uint FLASHW_CAPTION = 1;
        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        private const uint FLASHW_TRAY = 2;
        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        /// </summary>
        private const uint FLASHW_ALL = 3;
        /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
        private const uint FLASHW_TIMER = 4;
        /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
        private const uint FLASHW_TIMERNOFG = 12;

        /// <summary>
        /// Flash the spacified window until it recieves focus.
        /// </summary>
        /// <param name="windowHandle">The Window Handle to Flash.</param>
        /// <returns></returns>
        public static void Flash(IntPtr windowHandle)
        {
            FLASHWINFO flashInfo = new(windowHandle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, uint.MinValue);
            _ = FlashWindowEx(ref flashInfo);
        }
    }
}
