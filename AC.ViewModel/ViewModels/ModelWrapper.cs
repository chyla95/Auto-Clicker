using AC.Model.Models;

namespace AC.ViewModel.ViewModels
{
    public class ModelWrapper<TModel> : ViewModelBase
        where TModel : ModelBase
    {
        public TModel Model { get; }

        protected ModelWrapper(TModel model)
        {
            Model = model;
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
