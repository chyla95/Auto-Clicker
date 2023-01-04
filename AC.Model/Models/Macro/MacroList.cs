using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using AC.Model.Utilities;

namespace AC.Model.Models.Macro
{
    public class MacroList : IPersistable
    {
        public ObservableCollection<Macro> Macros { get; }
        public Macro? SelectedMacro { get; set; }

        public MacroList()
        {
            Macros = new();
        }

        public async Task SaveStateAsync(string directoryPath, string fileName)
        {
            bool doesDirectoryExist = Directory.Exists(directoryPath);
            if (!doesDirectoryExist) Directory.CreateDirectory(directoryPath);

            string fullPath = $@"{directoryPath}\{fileName}";
            bool doesFileExist = File.Exists(fullPath);
            if (!doesFileExist) File.Create(fullPath).Dispose();

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string dataToSave = JsonSerializer.Serialize(Macros, jsonSerializerOptions);
            await File.WriteAllTextAsync(fullPath, dataToSave);
        }
        public async Task LoadStateAsync(string directoryPath, string fileName)
        {
            bool doesDirectoryExist = Directory.Exists(directoryPath);
            if (!doesDirectoryExist) return;

            string fullPath = $@"{directoryPath}\{fileName}";
            bool doesFileExist = File.Exists(fullPath);
            if (!doesFileExist) return;

            string loadedData = await File.ReadAllTextAsync(fullPath);
            Debug.WriteLine(loadedData);

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNameCaseInsensitive = true,
            };
            //List<MacroJ>? state = JsonSerializer.Deserialize<List<MacroJ>>(loadedData, jsonSerializerOptions);
            //if (state == null) throw new FileLoadException();

            //Macros.Clear();
            //foreach (MacroJ macro in state)
            //{
            //    Macros.Add(macro);
            //}
            //public struct MacroJ
            //{
            //    public string Name { get; set; }
            //    public List<ActionJ> Actions { get; set; }
            //}
            //public struct ActionJ
            //{
            //    public int Id { get; set; }
            //    public ActionType ActionType { get; set; }
            //    public TimeSpan Delay { get; set; }
            //    public KeyCode KeyCode { get; set; }
            //    public KeyAction KeyAction { get; set; }
            //}
        }
    }
}

