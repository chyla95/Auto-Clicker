using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ObservableCollection<Process> _activeProcesses = new();
        public ObservableCollection<Process> ActiveProcesses
        {
            get { return _activeProcesses; }
            set
            {
                _activeProcesses = value;
                NotifyPropertyChanged();
            }
        }

        public int ActiveProcessCount
        {
            get
            {
                return ActiveProcesses.Count;
            }
        }

        public MainViewModel()
        {
            ActiveProcesses = new ObservableCollection<Process>(GetActiveProcesses());
        }

        private IEnumerable<Process> GetActiveProcesses()
        {
            Process applicationProcess = Process.GetCurrentProcess();

            IEnumerable<Process> processes = Process.GetProcesses()
                .Where(p => p.ProcessName != applicationProcess.ProcessName)
                .Where(p => p.MainWindowHandle != IntPtr.Zero);

            return processes;
        }
    }
}
