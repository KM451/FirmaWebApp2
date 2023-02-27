using FirmaMobileMauiApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace FirmaMobileMauiApp.ViewModels
{
    public abstract class AItemsViewModel<T> : BaseViewModel<T>
    {

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        private T _selectedItem;
        public ObservableCollection<T> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<T> ItemTapped { get; }
        public Command<T> DeleteItemCommand { get; }

        public AItemsViewModel(string title)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command<T>(OnDelete);
        }

        private async void OnDelete(T obj)
        {
            await DataStore.DeleteItemAsync(obj);
            await ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public abstract void GoToAddPage();
        public async void OnAddItem(object obj)
        {
            GoToAddPage();
        }
        public abstract void GoToDetailsPage(T item);

        async void OnItemSelected(T item)
        {
            if (item == null)
                return;
            GoToDetailsPage(item);

        }
    }
}

