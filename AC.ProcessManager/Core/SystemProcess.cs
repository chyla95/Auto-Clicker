using System.Diagnostics;

namespace AC.ProcessManager.Core
{
    public class SystemProcess
    {
        private readonly Process _process;

        public int Id
        {
            get
            {
                return _process.Id;
            }
        }
        public string Name
        {
            get
            {
                return _process.ProcessName;
            }
        }
        public Window Window { get; }

        public SystemProcess(Process process)
        {
            _process = process;
            Window = new Window(_process.MainWindowHandle, new Keyboard());
        }
    }
}
