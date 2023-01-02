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
        public ActionType ActionType
        {
            get
            {
                return Model.ActionType;
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
            }
        }
        public KeyAction KeyAction
        {
            get
            {
                return Model.KeyAction;
            }
            set
            {
                Model.KeyAction = value;
            }
        }

        public ActionViewModel(IAction model) : base(model) { }
    }
}
