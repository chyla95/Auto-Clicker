using System.Collections.ObjectModel;
using System.Collections.Specialized;
using AC.Model.Models;
using AC.ViewModel.ViewModels;

namespace AC.ViewModel.Utilities
{
    public class SynchronizableCollection<TViewModel, TModel> : ObservableCollection<TViewModel>
        where TViewModel : ModelWrapper<TModel>
        where TModel : ModelBase
    {
        private readonly ObservableCollection<TModel> _modelCollection;
        private bool _isSyncActive = true;

        /// <summary>
        /// Creates a new instance of SyncCollection
        /// </summary>
        /// <param name="modelCollection">The list of Models to sync to.</param>
        public SynchronizableCollection(ObservableCollection<TModel> modelCollection)
        {
            _modelCollection = modelCollection;

            // create ViewModels for all Model items in the modelCollection
            foreach (TModel model in _modelCollection) Add(CreateViewModel(model));

            CollectionChanged += SyncroniseModelCollections;
            _modelCollection.CollectionChanged += _modelCollection_CollectionChanged;
        }

        private void _modelCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (!_isSyncActive) return;
            _isSyncActive = false;

            Items.Clear();
            foreach (TModel item in _modelCollection)
            {
                Items.Add(CreateViewModel(item));
            }
            OnCollectionChanged(e);

            _isSyncActive = true;
        }

        private void SyncroniseModelCollections(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (!_isSyncActive) return;
            _isSyncActive = false;


            _modelCollection.Clear();
            foreach (TViewModel item in Items)
            {
                _modelCollection.Add(item.Model);
            }
            // https://stackoverflow.com/a/2177659/20798039
            // https://stackoverflow.com/a/15831128/20798039

            _isSyncActive = true;
        }

        private static TViewModel CreateViewModel(TModel model)
        {
            TViewModel? vm = (TViewModel)Activator.CreateInstance(typeof(TViewModel), new object[] { model });
            return vm!;
        }

        public TViewModel SingleByModel(TModel model)
        {
            return Items.Single(vm => vm.Model == model);
        }
        public TViewModel? SingleOrDefaultByModel(TModel model)
        {
            return Items.SingleOrDefault(vm => vm.Model == model);
        }
    }
}
