using System.Diagnostics;
using AC.Model.Models.Application;
using AC.Model.Models.Macro;
using AC.ViewModel.Utilities;
using AC.ViewModel.ViewModels.ApplicationViewModels;
using AC.ViewModel.ViewModels.MacroViewModels;
using PeripheralDeviceEmulator.Keyboard;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MacroListViewModel MacroList { get; }
        public ApplicationListViewModel ApplicationList { get; }

        private bool _isLoopActive;
        public bool IsLoopActive
        {
            get { return _isLoopActive; }
            set
            {
                _isLoopActive = value;
                NotifyPropertyChanged();
                Debug.WriteLine("Pong.");
            }
        }

        public RelayCommand<object> StartLoopCommand { get; }

        public MainViewModel()
        {
            StartLoopCommand = new RelayCommand<object>(StartLoopCommandExecute);

            MacroList = new(new MacroList());
            KeyboardEmulator keyboardEmulator = new();
            ApplicationList = new(new ApplicationList(keyboardEmulator));
        }

        private void StartLoopCommandExecute(object? application)
        {
            Debug.WriteLine("Ping.");
        }
    }
}
