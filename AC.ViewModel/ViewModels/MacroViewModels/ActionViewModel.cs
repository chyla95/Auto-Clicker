using AC.Model.Models.Macro;
using PeripheralDeviceEmulator.Constants;

namespace AC.ViewModel.ViewModels.MacroViewModels
{
    public class ActivityViewModel : ModelWrapper<Activity>
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }
        public KeyAction KeyAction
        {
            get
            {
                return Model.KeyAction;
            }
        }

        public ActivityViewModel(Activity model) : base(model) { }
    }
}
