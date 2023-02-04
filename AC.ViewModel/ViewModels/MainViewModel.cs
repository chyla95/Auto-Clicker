using AC.Model.Models;
using AC.ViewModel.Utilities;
using AC.ViewModel.Utilities.Services;
using AC.ViewModel.ViewModels.ApplicationViewModels;
using AC.ViewModel.ViewModels.MacroViewModels;
using PeripheralDeviceEmulator.Constants;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ModelWrapper<AutoClicker>
    {
        public AutoClicker AutoClicker { get; }
        public IDialogService DialogService { get; set; }

        public MacroListViewModel MacroList { get; }
        public ApplicationListViewModel ApplicationList { get; }

        public bool IsPlaying
        {
            get
            {
                return Model.IsPlaying;
            }
            set
            {
                Model.IsPlaying = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> TogglePlayCommand { get; }

        public MainViewModel(AutoClicker autoClicker, IDialogService dialogService) : base(autoClicker)
        {
            AutoClicker = autoClicker;
            DialogService = dialogService;

            TogglePlayCommand = new RelayCommand<object>(TogglePlayCommandExecute);

            MacroList = new(Model.MacroList);
            ApplicationList = new(Model.ApplicationList);
        }

        private async void TogglePlayCommandExecute(object? application)
        {
            if (!IsPlaying)
            {
                try
                {
                    await Model.PlayRepeatedly();
                }
                catch (Exception e)
                {
                    await DialogService.ShowError(e.Message);
                    IsPlaying = false;
                    return;
                }
            }                
            else Model.StopPlaying();
        }
    }
}
