using PeripheralDeviceEmulator.Constants;
using Window = AC.Model.Models.Application.Window;

namespace AC.Model.Models.Macro
{
    public class KeyboardAction : IAction
    {
        public int Id { get; private set; }
        public ActionType ActionType { get; private set; }

        public TimeSpan Delay { get; set; }
        public KeyCode KeyCode { get; set; }
        public KeyAction KeyAction { get; set; }

        public KeyboardAction(int id, TimeSpan delay, KeyCode keyCode, KeyAction keyAction)
        {
            Id = id;
            Delay = delay;
            KeyCode = keyCode;
            KeyAction = keyAction;
        }

        public async Task Execute(Window window)
        {
            window.PostKey(KeyCode, KeyAction);
            await Task.Delay(Delay);
        }
    }
}
