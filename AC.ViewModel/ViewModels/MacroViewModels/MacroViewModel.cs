using System.ComponentModel.DataAnnotations;
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
                NotifyPropertyChanged();
            }
        }
        public SynchronizableCollection<ActionViewModel, IAction> Actions { get; }

        public RelayCommand<object> AddKeyboardActionCommand { get; }
        public RelayCommand<ActionViewModel> RemoveActionCommand { get; }

        public MacroViewModel(Macro model) : base(model)
        {
            Actions = new(Model.Actions);

            AddKeyboardActionCommand = new RelayCommand<object>(AddKeyboardActionCommandExecute);
            RemoveActionCommand = new RelayCommand<ActionViewModel>(RemoveActionCommandExecute);
        }

        private void AddKeyboardActionCommandExecute(object? o)
        {
            int actionId = 1;
            if(Actions.Count > 0) actionId = Actions.OrderBy(a => a.Id).Last().Id + 1;

            IAction keyboardAction_keyDown = new KeyboardAction(actionId, TimeSpan.FromMilliseconds(100), KeyCode.A, KeyAction.KeyDown);
            IAction keyboardAction_keyUp = new KeyboardAction(actionId, TimeSpan.FromMilliseconds(100), KeyCode.A, KeyAction.KeyUp);
            Actions.Add(new ActionViewModel(keyboardAction_keyDown));
            Actions.Add(new ActionViewModel(keyboardAction_keyUp));
        }
        private void RemoveActionCommandExecute(ActionViewModel? action)
        {
            if (action == null) throw new NullReferenceException(nameof(action));

            while (Actions.Any(a => a.Id == action.Id))
            {
                ActionViewModel actionToRemove = Actions.First(a => a.Id == action.Id);
                Actions.Remove(actionToRemove);
            }
        }
    }
}
