using AC.Model.Models.Macro;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels.MacroViewModels
{
    public class MacroListViewModel : ModelWrapper<MacroList>
    {
        public SynchronizableCollection<MacroViewModel, Macro> Macros { get; set; }
        public MacroViewModel? SelectedMacro
        {
            get
            {
                if (Model.SelectedMacro == null) return default;
                return Macros.SingleByModel(Model.SelectedMacro);
            }
            set
            {
                if (value == null)
                {
                    Model.SelectedMacro = null;
                }
                else
                {
                    Model.SelectedMacro = value.Model;
                }
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<object> AddMacroCommand { get; }
        public RelayCommand<MacroViewModel> RemoveMacroCommand { get; }
        public RelayCommand<MacroViewModel> SelectMacroCommand { get; }

        public MacroListViewModel(MacroList model) : base(model)
        {
            Macros = new(Model.Macros);
            AddMacroCommand = new RelayCommand<object>(AddMacroCommandExecute);
            RemoveMacroCommand = new RelayCommand<MacroViewModel>(RemoveMacroCommandExecute);
            SelectMacroCommand = new RelayCommand<MacroViewModel>(SelectMacroCommandExecute);
        }

        private void AddMacroCommandExecute(object? o)
        {
            Macro macro = new("New Macro");
            Macros.Add(new MacroViewModel(macro));
        }
        private void RemoveMacroCommandExecute(MacroViewModel? macro)
        {
            if (macro == null) throw new NullReferenceException(nameof(macro));
            if (macro == SelectedMacro) SelectedMacro = null;
            Macros.Remove(macro);
        }
        private void SelectMacroCommandExecute(MacroViewModel? macro)
        {
            if (macro == null) throw new NullReferenceException(nameof(macro));
            SelectedMacro = macro;
        }
    }
}
