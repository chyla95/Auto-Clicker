using PeripheralDeviceEmulator.Constants;

namespace AC.Model.Models.Macro
{
    public abstract class Activity : ModelBase
    {
        public int Id { get; }
        public TimeSpan Delay { get; set; }
        public KeyCode KeyCode { get; set; }
        public KeyAction KeyAction { get; }

        public Activity(int id, TimeSpan delay, KeyCode keyCode, KeyAction keyAction)
        {
            Id = id;
            Delay = delay;
            KeyCode = keyCode;
            KeyAction = keyAction;
        }
    }
}
