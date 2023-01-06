using AC.Model.Models.Application;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels.ApplicationViewModels
{
    public class ApplicationListViewModel : ModelWrapper<ApplicationList>
    {
        public SynchronizableCollection<ApplicationViewModel, Application> Applications { get; }

        public RelayCommand<object> RefreshApplicationsCommand { get; }

        public ApplicationListViewModel(ApplicationList model) : base(model)
        {
            Applications = new(Model.Applications);
            RefreshApplicationsCommand = new RelayCommand<object>(RefreshApplicationsCommandExecute);
        }

        private void RefreshApplicationsCommandExecute(object? o)
        {
            Model.RefreshApplications();
        }
    }
}
