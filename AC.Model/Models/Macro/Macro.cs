using System.Collections.ObjectModel;

namespace AC.Model.Models.Macro
{
    public class Macro
    {
        public string Name { get; set; }
        public ObservableCollection<IAction> Actions { get; }

        public Macro(string name)
        {
            Name = name;
            Actions = new();
        }
    }
}
