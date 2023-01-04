using AC.Model.Models.Application;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels.ApplicationViewModels
{
    public class WindowViewModel : ModelWrapper<Window>
    {
        public string Title
        {
            get
            {
                return Model.Title;
            }
            set
            {
                Model.Title = value;
                OnPropertyChanged();
            }
        }
        public SynchronizableCollection<WindowViewModel, Window> ChildWindows { get; }

        public WindowViewModel(Window model) : base(model)
        {
            ChildWindows = new(Model.ChildWindows);
        }
    }
}
