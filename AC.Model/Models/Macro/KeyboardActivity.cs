using PeripheralDeviceEmulator.Constants;

namespace AC.Model.Models.Macro
{
    public class KeyboardActivity : Activity
    {
        public KeyboardActivity(int id, TimeSpan delay, KeyCode keyCode, KeyAction keyAction) : base(id, delay, keyCode, keyAction)
        {

        }
    }
}
