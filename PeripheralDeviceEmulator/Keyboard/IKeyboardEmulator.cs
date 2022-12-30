using PeripheralDeviceEmulator.Common;
using PeripheralDeviceEmulator.Constants;

namespace PeripheralDeviceEmulator.Keyboard
{
    public interface IKeyboardEmulator
    {
        public IKey? GetKey(KeyCode code);
    }
}
