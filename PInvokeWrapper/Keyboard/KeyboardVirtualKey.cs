using System.Runtime.InteropServices;

namespace PInvokeWrapper.Keyboard
{
    public static partial class Keyboard
    {
        /// <summary>
        /// Virtual key types for MapVirtualKey method.
        /// </summary>
        public enum MapVirtualKeyMapTypes : uint
        {
            /// <summary>
            /// uCode is a virtual-key code and is translated into a scan code.
            /// If it is a virtual-key code that does not distinguish between left- and
            /// right-hand keys, the left-hand scan code is returned.
            /// If there is no translation, the function returns 0.
            /// </summary>
            MAPVK_VK_TO_VSC = 0x00,

            /// <summary>
            /// uCode is a scan code and is translated into a virtual-key code that
            /// does not distinguish between left- and right-hand keys. If there is no
            /// translation, the function returns 0.
            /// </summary>
            MAPVK_VSC_TO_VK = 0x01,

            /// <summary>
            /// uCode is a virtual-key code and is translated into an unshifted
            /// character value in the low-order word of the return value. Dead keys (diacritics)
            /// are indicated by setting the top bit of the return value. If there is no
            /// translation, the function returns 0.
            /// </summary>
            MAPVK_VK_TO_CHAR = 0x02,

            /// <summary>
            /// Windows NT/2000/XP: uCode is a scan code and is translated into a
            /// virtual-key code that distinguishes between left- and right-hand keys. If
            /// there is no translation, the function returns 0.
            /// </summary>
            MAPVK_VSC_TO_VK_EX = 0x03,

            /// <summary>
            /// Not currently documented
            /// </summary>
            MAPVK_VK_TO_VSC_EX = 0x04
        }

        /// <summary>
        /// The MapVirtualKey function translates (maps) a virtual-key code into a scan code
        /// or character value, or translates a scan code into a virtual-key code.  
        /// </summary>
        /// <param name="uCode">Specifies the virtual-key code or scan code for a key.
        /// How this value is interpreted depends on the value of the uMapType parameter
        /// </param>
        /// <param name="uMapType">Specifies the translation to perform. The value of this
        /// parameter depends on the value of the uCode parameter.
        /// </param>
        /// <returns>Either a scan code, a virtual-key code, or a character value, depending on
        /// the value of uCode and uMapType. If there is no translation, the return value is zero
        /// </returns>
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey([In] uint uCode, [In] uint uMapType);

        /// <summary>
        /// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
        /// </summary>
        /// <param name="virtualKeyCode">Specifies the virtual-key code or scan code for a key.</param>
        /// <param name="mapType">Specifies the translation to perform.</param>
        /// <returns>Either a scan code, a virtual-key code, or a character value, depending on the value of uCode and uMapType.
        /// If there is no translation, the return value is null.</returns>
        public static uint? MapVirtualKeyM(uint virtualKeyCode, MapVirtualKeyMapTypes mapType)
        {
            uint result = MapVirtualKey(virtualKeyCode, (uint)mapType);
            if (result == 0) return null;
            return result;
        }
    }
}
