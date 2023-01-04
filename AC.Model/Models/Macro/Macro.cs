using System.Collections.ObjectModel;

namespace AC.Model.Models.Macro
{
    public class Macro : ModelBase
    {
        public string Name { get; set; }
        public ObservableCollection<Activity> Activities { get; } = new();

        public Macro(string name)
        {
            Name = name;
        }
    }
}
