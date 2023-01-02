using AC.Model.Models.Application;
using AC.ViewModel.Utilities;
using PeripheralDeviceEmulator.Constants;

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
                NotifyPropertyChanged();
            }
        }
        public SynchronizableCollection<WindowViewModel, Window> ChildWindows { get; }

        public WindowViewModel(Window model) : base(model)
        {
            ChildWindows = new(Model.ChildWindows);
        }

        public void PostKey(KeyCode keyCode, KeyAction keyAction)
        {
            Model.PostKey(keyCode, keyAction);
        }
        public void SendKey(KeyCode keyCode, KeyAction keyAction)
        {
            Model.SendKey(keyCode, keyAction);
        }
    }
}
