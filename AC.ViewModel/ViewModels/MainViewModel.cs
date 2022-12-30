using System.Collections.ObjectModel;
using System.Diagnostics;
using AC.Model.Models.Application;
using AC.ViewModel.Utilities;
using PeripheralDeviceEmulator.Constants;
using PeripheralDeviceEmulator.Keyboard;
using Window = AC.Model.Models.Application.Window;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ObservableCollection<Application> _applications = new();

        public ObservableCollection<Application> Applications
        {
            get { return _applications; }
            set
            {
                _applications = value;
                NotifyPropertyChanged();
            }
        }
        public int ApplicationCount
        {
            get
            {
                return Applications.Count;
            }
        }

        private void UpdateApplications()
        {
            Process currentProcess = Process.GetCurrentProcess();
            IEnumerable<Process> processes = Process.GetProcesses();

            Application currentApplication = new(currentProcess, new KeyboardEmulator());
            IEnumerable<Application> applications = processes.Select(p => new Application(p, new KeyboardEmulator()));

            IEnumerable<Application> filteredApplications = applications
                .Where(p => p.Name != currentApplication.Name)
                .Where(p => p.Window != null)
                .Where(p => !string.IsNullOrEmpty(p.Window!.Title));

            Applications = new(filteredApplications);
        }

        public RelayCommand<Application> ShowProcessCommand { get; }
        private async void ShowProcessCommandExecute(Application? application)
        {
            if (application == null) throw new NullReferenceException(nameof(application));

            application.Window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
            await Task.Delay(100);
            application.Window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
            await Task.Delay(100);
            application.Window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
            await Task.Delay(100);
            application.Window!.PostKey(KeyCode.Number0, KeyAction.KeyUp);

            foreach (Window window in application.Window.ChildWindows)
            {
                window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
                await Task.Delay(100);
                window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
                await Task.Delay(100);
                window!.PostKey(KeyCode.Number0, KeyAction.KeyDown);
                await Task.Delay(100);
                window!.PostKey(KeyCode.Number0, KeyAction.KeyUp);
            }
        }

        public MainViewModel()
        {
            ShowProcessCommand = new RelayCommand<Application>(ShowProcessCommandExecute);
            UpdateApplications();
        }
    }
}
