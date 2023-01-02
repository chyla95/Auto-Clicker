using AC.Model.Models.Application;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels.ApplicationViewModels
{
    public class ApplicationListViewModel : ModelWrapper<ApplicationList>
    {
        public SynchronizableCollection<ApplicationViewModel, Application> Applications { get; }

        public ApplicationListViewModel(ApplicationList model) : base(model)
        {
            Applications = new(Model.Applications);
        }
    }
}
