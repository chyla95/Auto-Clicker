using AC.Model.Models.Application;
using PeripheralDeviceEmulator.Constants;

namespace AC.Model.Models.Macro
{
    public enum ActionType
    {
        Opening,
        Encloseing,
        SelfEnclosing
    }

    public interface IAction
    {
        public int Id { get; }
        public ActionType ActionType { get; }

        public TimeSpan Delay { get; set; }
        public KeyCode KeyCode { get; set; }
        public KeyAction KeyAction { get; set; }

        public abstract Task Execute(Window window);
    }
}
