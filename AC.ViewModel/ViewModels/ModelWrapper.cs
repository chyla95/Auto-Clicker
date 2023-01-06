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
            Model.PropertyChanged += PropagatePropertyChangedEventFromModelToViewModel;
        }

        private void PropagatePropertyChangedEventFromModelToViewModel(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
