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
            get { 
                return Model.IsPlaying; }
            set
            {
                Model.IsPlaying = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> StartLoopCommand { get; }

        public MainViewModel() : base(new Main())
        {
            StartLoopCommand = new RelayCommand<object>(StartLoopCommandExecute);

            MacroList = new(Model.MacroList);
            ApplicationList = new(Model.ApplicationList);
        }

        private async void StartLoopCommandExecute(object? application)
        {
            await Model.PlayRepeatedly();
        }
    }
}
