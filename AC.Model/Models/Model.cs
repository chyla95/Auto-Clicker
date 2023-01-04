using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AC.Model.Models
{
    public class ModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
