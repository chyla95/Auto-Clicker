using System.Collections.ObjectModel;

namespace AC.Model.Models.Macro
{
    public class MacroList
    {
        public ObservableCollection<Macro> Macros { get; private set; }

        public MacroList()
        {
            Macros = new();
        }
    }
}

