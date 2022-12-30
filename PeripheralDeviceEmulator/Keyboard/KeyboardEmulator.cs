using PeripheralDeviceEmulator.Common;
using PeripheralDeviceEmulator.Constants;

namespace PeripheralDeviceEmulator.Keyboard
{
    public class KeyboardEmulator : IKeyboardEmulator
    {
        public List<IKey> Keys { get; } = new()
        {
            new Key(KeyCode.Number0),
            new Key(KeyCode.Number1),
            new Key(KeyCode.Number2),
            new Key(KeyCode.Number3),
            new Key(KeyCode.Number4),
            new Key(KeyCode.Number5),
            new Key(KeyCode.Number6),
            new Key(KeyCode.Number7),
            new Key(KeyCode.Number8),
            new Key(KeyCode.Number9),

            new Key(KeyCode.A),
            new Key(KeyCode.B),
            new Key(KeyCode.C),
            new Key(KeyCode.D),
            new Key(KeyCode.E),
            new Key(KeyCode.F),
            new Key(KeyCode.G),
            new Key(KeyCode.H),
            new Key(KeyCode.I),
            new Key(KeyCode.J),
            new Key(KeyCode.K),
            new Key(KeyCode.L),
            new Key(KeyCode.M),
            new Key(KeyCode.N),
            new Key(KeyCode.O),
            new Key(KeyCode.P),
            new Key(KeyCode.Q),
            new Key(KeyCode.R),
            new Key(KeyCode.S),
            new Key(KeyCode.T),
            new Key(KeyCode.U),
            new Key(KeyCode.V),
            new Key(KeyCode.W),
            new Key(KeyCode.X),
            new Key(KeyCode.Y),
            new Key(KeyCode.Z),

            new Key(KeyCode.F1),
            new Key(KeyCode.F2),
            new Key(KeyCode.F3),
            new Key(KeyCode.F4),
            new Key(KeyCode.F5),
            new Key(KeyCode.F6),
            new Key(KeyCode.F7),
            new Key(KeyCode.F8),
            new Key(KeyCode.F9),
            new Key(KeyCode.F10),
            new Key(KeyCode.F11),
            new Key(KeyCode.F12),

            new Key(KeyCode.Oem1),
            new Key(KeyCode.Oem2),
            new Key(KeyCode.Oem3),
            new Key(KeyCode.Oem4),
            new Key(KeyCode.Oem5),
            new Key(KeyCode.Oem6),
            new Key(KeyCode.Oem7),
            new Key(KeyCode.Oem8),

            new Key(KeyCode.Escape),
            new Key(KeyCode.Tab),
            new Key(KeyCode.CapitalLock),
            new Key(KeyCode.Shift),
            new Key(KeyCode.LeftShift),
            new Key(KeyCode.RightShift),
            new Key(KeyCode.Control),
            new Key(KeyCode.LeftControl),
            new Key(KeyCode.RightControl),
            new Key(KeyCode.LeftWindows),
            new Key(KeyCode.RightWindows),
            new Key(KeyCode.Menu),
            new Key(KeyCode.LeftMenu),
            new Key(KeyCode.RightMenu),
            new Key(KeyCode.Space),
            new Key(KeyCode.Application),
            new Key(KeyCode.Back),
            new Key(KeyCode.Enter),
            new Key(KeyCode.Shift),
            new Key(KeyCode.LeftShift),
            new Key(KeyCode.RightShift),

            new Key(KeyCode.Snapshot),
            new Key(KeyCode.Scroll),
            new Key(KeyCode.Pause),

            new Key(KeyCode.Insert),
            new Key(KeyCode.Delete),
            new Key(KeyCode.Home),
            new Key(KeyCode.End),
            new Key(KeyCode.PageUp),
            new Key(KeyCode.PageDown),

            new Key(KeyCode.Up),
            new Key(KeyCode.Down),
            new Key(KeyCode.Left),
            new Key(KeyCode.Right),

            new Key(KeyCode.NumberKeyLock),
            new Key(KeyCode.NumberPad0),
            new Key(KeyCode.NumberPad1),
            new Key(KeyCode.NumberPad2),
            new Key(KeyCode.NumberPad3),
            new Key(KeyCode.NumberPad4),
            new Key(KeyCode.NumberPad5),
            new Key(KeyCode.NumberPad6),
            new Key(KeyCode.NumberPad7),
            new Key(KeyCode.NumberPad8),
            new Key(KeyCode.NumberPad9),

            new Key(KeyCode.Divide),
        };

        public IKey? GetKey(KeyCode code)
        {
            IKey? key = Keys.Single(k => k.Code == code);
            return key;
        }
    }
}
