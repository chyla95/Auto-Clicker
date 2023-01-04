using PeripheralDeviceEmulator.Constants;

namespace AC.Model.Models.Macro
{
    public class KeyboardAction : IAction
    {
        public int Id { get; private set; }
        public TimeSpan Delay { get; set; }
        public KeyCode KeyCode { get; set; }
        public KeyAction KeyAction { get; }

        public KeyboardAction(int id, TimeSpan delay, KeyCode keyCode, KeyAction keyAction)
        {
            Id = id;
            Delay = delay;
            KeyCode = keyCode;
            KeyAction = keyAction;
        }
    }
}
