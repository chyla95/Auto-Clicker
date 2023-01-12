using System.Collections.ObjectModel;
using AC.Model.Models.Application;

namespace AC.Model.Models.Macro
{
    public class Macro : ModelBase
    {
        public string Name { get; set; }
        public MacroBehaviour Behaviour { get; set; }
        public KeyPressMethod KeyPressMethod { get; set; }
        public Pivot Pivot { get; set; }


        public ObservableCollection<Activity> Activities { get; } = new();

        public Macro(string name)
        {
            Name = name;
            Behaviour = MacroBehaviour.Natural;
            KeyPressMethod = KeyPressMethod.Post;
            Pivot = Pivot.Application;
        }
    }
    public enum MacroBehaviour
    {
        Precise,
        Natural
    }
    public enum Pivot
    {
        Activity,
        Application
    }
}
