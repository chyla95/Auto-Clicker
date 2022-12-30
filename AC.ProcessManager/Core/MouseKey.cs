using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.ProcessManager.Core
{
    internal class MouseKey
    {
        public enum MouseKeys : uint
        {
            // Left mouse button
            VK_LBUTTON = 0x01,
            // Right mouse button
            VK_RBUTTON = 0x02,
            // Middle mouse button (three-button mouse)
            VK_MBUTTON = 0x04,
            // X1 mouse button
            VK_XBUTTON1 = 0x05,
            // X2 mouse button
            VK_XBUTTON2 = 0x06,
        }
        public enum MouseKeyActions : uint
        {
            // https://wiki.winehq.org/List_Of_Windows_Messages
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_LBUTTONDBLCLK = 0x0203,
        }
    }
}
