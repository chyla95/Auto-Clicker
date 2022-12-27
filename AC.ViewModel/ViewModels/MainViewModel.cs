using System.Collections.ObjectModel;
using System.Diagnostics;
using AC.ProcessManager;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ObservableCollection<SystemProcess> _activeProcesses = new();
        public ObservableCollection<SystemProcess> ActiveProcesses
        {
            get { return _activeProcesses; }
            set
            {
                _activeProcesses = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<SystemProcess> ShowProcessCommand { get; }
        private void ShowProcessCommandExecute(SystemProcess? process)
        {
            Debug.WriteLine(process!.Id + " " + process.WindowHandle);
            //process.ShowWindow();
            //process.SendKey();
            process.FlashWindow();
            //process.SetWindowTitle("Tit");
            Debug.WriteLine(process.GetWindowTitle());
            process.SetWindowTitle($"[AC:{process.Id}] {process.GetWindowTitle()}");
        }



        public int ActiveProcessCount
        {
            get
            {
                return ActiveProcesses.Count;
            }
        }

        public PeriodicTimer RefreshProcessListTimer { get; set; }
        async Task HandleTimerAsync(PeriodicTimer timer)
        {
            while (await timer.WaitForNextTickAsync())
            {
                ActiveProcesses = new ObservableCollection<SystemProcess>(ProcessManager.ProcessManager.GetProcesses());
            }
        }


        public MainViewModel()
        {
            ActiveProcesses = new ObservableCollection<SystemProcess>(ProcessManager.ProcessManager.GetProcesses());
            ShowProcessCommand = new RelayCommand<SystemProcess>(ShowProcessCommandExecute);

            RefreshProcessListTimer = new(TimeSpan.FromSeconds(1));
            HandleTimerAsync(RefreshProcessListTimer);
        }
    }
}
