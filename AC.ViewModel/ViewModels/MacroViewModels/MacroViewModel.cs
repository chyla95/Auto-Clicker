using AC.Model.Models.Application;
using AC.Model.Models.Macro;
using AC.ViewModel.Utilities;
using PeripheralDeviceEmulator.Constants;

namespace AC.ViewModel.ViewModels.MacroViewModels
{
    public class MacroViewModel : ModelWrapper<Macro>
    {
        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
                OnPropertyChanged();
            }
        }
        public MacroBehaviour Behaviour
        {
            get
            {
                return Model.Behaviour;
            }
            set
            {
                Model.Behaviour = value;
            }
        }
        public KeyPressMethod KeyPressMethod
        {
            get
            {
                return Model.KeyPressMethod;
            }
            set
            {
                Model.KeyPressMethod = value;
            }
        }
        public Pivot Pivot
        {
            get
            {
                return Model.Pivot;
            }
            set
            {
                Model.Pivot = value;
            }
        }

        public SynchronizableCollection<ActivityViewModel, Activity> Activities { get; }

        public RelayCommand<object> AddKeyboardActionCommand { get; }
        public RelayCommand<ActivityViewModel> RemoveActionCommand { get; }

        public MacroViewModel(Macro model) : base(model)
        {
            Activities = new(Model.Activities);

            AddKeyboardActionCommand = new RelayCommand<object>(AddKeyboardActionCommandExecute);
            RemoveActionCommand = new RelayCommand<ActivityViewModel>(RemoveActionCommandExecute);
        }

        private void AddKeyboardActionCommandExecute(object? o)
        {
            int actionId = 1;
            if (Activities.Count > 0) actionId = Activities.OrderBy(a => a.Id).Last().Id + 1;

            Activity keyboardAction_keyDown = new KeyboardActivity(actionId, TimeSpan.FromMilliseconds(100), KeyCode.None, KeyAction.KeyDown);
            Activity keyboardAction_keyUp = new KeyboardActivity(actionId, TimeSpan.FromMilliseconds(3000), KeyCode.None, KeyAction.KeyUp);
            Activities.Add(new ActivityViewModel(keyboardAction_keyDown));
            Activities.Add(new ActivityViewModel(keyboardAction_keyUp));
        }
        private void RemoveActionCommandExecute(ActivityViewModel? action)
        {
            if (action == null) throw new NullReferenceException(nameof(action));

            while (Activities.Any(a => a.Id == action.Id))
            {
                ActivityViewModel actionToRemove = Activities.First(a => a.Id == action.Id);
                Activities.Remove(actionToRemove);
            }
        }
    }
}
