using System.Collections.ObjectModel;
using PeripheralDeviceEmulator.Keyboard;
using System.Diagnostics;

namespace AC.Model.Models.Application
{
    public class ApplicationList : ModelBase
    {
        private readonly IKeyboardEmulator _keyboardEmulator;

        public ObservableCollection<Application> Applications { get; }

        public ApplicationList(IKeyboardEmulator keyboardEmulator)
        {
            _keyboardEmulator = keyboardEmulator;
            Applications = new(GetFilteredApplications(_keyboardEmulator));
        }

        private static Application GetCurrentApplication(IKeyboardEmulator keyboardEmulator)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Application currentApplication = new(currentProcess, keyboardEmulator);

            return currentApplication;
        }
        private static IEnumerable<Application> GetApplications(IKeyboardEmulator keyboardEmulator)
        {
            IEnumerable<Process> processes = Process.GetProcesses();
            IEnumerable<Application> applications = processes.Select(p => new Application(p, keyboardEmulator));

            return applications;
        }
        private static IEnumerable<Application> GetFilteredApplications(IKeyboardEmulator keyboardEmulator)
        {
            Application currentApplication = GetCurrentApplication(keyboardEmulator);
            IEnumerable<Application> applications = GetApplications(keyboardEmulator);

            IEnumerable<Application> filteredApplications = applications
                .Where(p => p.Name != currentApplication.Name)
                .Where(p => p.Window != null)
                .Where(p => !string.IsNullOrEmpty(p.Window!.Title));
            
            return filteredApplications;
        }
        public void RefreshApplications()
        {
            IEnumerable<Application> refreshedApplications = GetFilteredApplications(_keyboardEmulator);
            Applications.Clear();

            IEnumerable<Application> persistedApplications = Applications.Where(a => refreshedApplications.Contains(a));
            foreach (Application application in persistedApplications)
            {
                Applications.Add(application);
            }

            IEnumerable<Application> newApplications = refreshedApplications.Where(na => !Applications.Contains(na));
            foreach (Application application in newApplications)
            {
                Applications.Add(application);
            }
        }
    }
}
