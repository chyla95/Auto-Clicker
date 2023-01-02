namespace AC.Model.Models.Macro
{
    public class Macro
    {
        public string Name { get; set; }
        public List<IAction> Actions { get; } = new List<IAction>();

        public Macro(string name)
        {
            Name = name;
        }
    }
}
