using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AC.Model.Models.Macro
{
    public class Macro : ModelBase
    {
        public string Name { get; set; }
        public MacroBehaviour Behaviour { get; set; }
        public ObservableCollection<Activity> Activities { get; } = new();

        public Macro(string name)
        {
            Name = name;
            Behaviour = MacroBehaviour.Natural;
        }
    }
    public enum MacroBehaviour
    {
        Precise,
        Natural
    }
}
