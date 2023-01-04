using AC.Model.Models.Macro;
using AC.ViewModel.Utilities;

namespace AC.ViewModel.ViewModels.MacroViewModels
{
    public class MacroListViewModel : ModelWrapper<MacroList>
    {
        private readonly string DATA_DIRECTORY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AC";
        private readonly string DATA_FILE_NAME = @"\Macros.json";

        public SynchronizableCollection<MacroViewModel, Macro> Macros { get; set; }
        public MacroViewModel? SelectedMacro
        {
            get
            {
                if (Model.SelectedMacro == null) return null;
                return Macros.SingleByModel(Model.SelectedMacro);
            }
            set
            {
                if (value == null)
                {
                    Model.SelectedMacro = null;
                    return;
                }
                Model.SelectedMacro = value.Model;
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

        public async Task SaveStateAsync()
        {
            await Model.SaveStateAsync(DATA_DIRECTORY_PATH, DATA_FILE_NAME);
        }
        public async Task LoadStateAsync()
        {
            await Model.LoadStateAsync(DATA_DIRECTORY_PATH, DATA_FILE_NAME);
        }
    }
}
