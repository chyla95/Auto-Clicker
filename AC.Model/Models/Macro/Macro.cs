using System.Collections.ObjectModel;

namespace AC.Model.Models.Macro
{
    public class Macro
    {
        public string Name { get; set; }
        public ObservableCollection<IAction> Actions { get; } = new();

        public Macro(string name)
        {
            Name = name;
        }
    }
}
