using AC.Model.Models.Application;

namespace AC.ViewModel.ViewModels.ApplicationViewModels
{
    public class ApplicationViewModel : ModelWrapper<Application>
    {
        public bool IsSelected
        {
            get
            {
                return Model.IsSelected;
            }
            set
            {
                Model.IsSelected = value;
                NotifyPropertyChanged();
            }
        }
        public int Id
        {
            get
            {
                return Model.Id;
            }
        }
        public string Name
        {
            get
            {
                return Model.Name;
            }
        }
        public WindowViewModel? Window
        {
            get
            {
                if (Model.Window == null) return default;
                return new(Model.Window);
            }
        }

        public ApplicationViewModel(Application model) : base(model) { }
    }
}
