using System.Diagnostics;
using AC.ProcessManager.Core;

namespace AC.ProcessManager
{
    public class ProcessManager
    {
        public static SystemProcess GetCurrentProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            return new SystemProcess(currentProcess);
        }

        public static IEnumerable<SystemProcess> GetProcesses()
        {
            SystemProcess currentProcess = GetCurrentProcess();

            IEnumerable<SystemProcess> processes = Process.GetProcesses()
                .Select(p => new SystemProcess(p));

            return processes
                .Where(p => p.Name != currentProcess.Name)
                .Where(p => !string.IsNullOrEmpty(p.Window.Text))
                .Where(p => p.Window.Handle != IntPtr.Zero);
        }
    }
}