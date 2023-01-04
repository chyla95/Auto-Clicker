using AC.Model.Models.Macro;
using PeripheralDeviceEmulator.Constants;

namespace AC.ViewModel.ViewModels.MacroViewModels
{
    public class ActionViewModel : ModelWrapper<IAction>
    {
        public int Id
        {
            get
            {
                return Model.Id;
            }
        }
        public TimeSpan Delay
        {
            get
            {
                return Model.Delay;
            }
            set
            {
                Model.Delay = value;
                NotifyPropertyChanged();
            }
        }
        public KeyCode KeyCode
        {
            get
            {
                return Model.KeyCode;
            }
            set
            {
                 Model.KeyCode = value;
                NotifyPropertyChanged();
            }
        }
        public KeyAction KeyAction
        {
            get
            {
                return Model.KeyAction;
            }
        }

        public ActionViewModel(IAction model) : base(model) { }
    }
}
