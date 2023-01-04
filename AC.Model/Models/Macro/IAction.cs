using AC.Model.Models.Application;
using PeripheralDeviceEmulator.Constants;

namespace AC.Model.Models.Macro
{
    public interface IAction
    {
        public int Id { get; }
        public TimeSpan Delay { get; set; }
        public KeyCode KeyCode { get; set; }
        public KeyAction KeyAction { get; }

        public abstract Task Execute(Window window);
    }
}
