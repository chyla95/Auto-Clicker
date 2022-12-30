using PeripheralDeviceEmulator.Constants;

namespace PeripheralDeviceEmulator.Common
{
    public interface IKey
    {
        public KeyCode Code { get; }
        public bool IsPressed { get; }

        public void Post(IntPtr windowHandle, KeyAction keyAction);
        public void Send(IntPtr windowHandle, KeyAction keyAction);
    }
}
