namespace AC.ViewModel.ViewModels
{
    public class ModelWrapper<TModel> : ViewModel
        where TModel : class
    {
        public TModel Model { get; }

        public ModelWrapper(TModel model)
        {
            Model = model;
        }
    }
}
