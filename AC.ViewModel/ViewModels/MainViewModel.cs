using AC.Model.Models;
using AC.ViewModel.Utilities;
using AC.ViewModel.ViewModels.ApplicationViewModels;
using AC.ViewModel.ViewModels.MacroViewModels;

namespace AC.ViewModel.ViewModels
{
    public class MainViewModel : ModelWrapper<Main>
    {
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

        public MainViewModel() : base(new Main())
        {
            TogglePlayCommand = new RelayCommand<object>(TogglePlayCommandExecute);

            MacroList = new(Model.MacroList);
            ApplicationList = new(Model.ApplicationList);
        }

        private async void TogglePlayCommandExecute(object? application)
        {
            if(!IsPlaying) await Model.PlayRepeatedly();
            else Model.StopPlaying();
        }
    }
}
