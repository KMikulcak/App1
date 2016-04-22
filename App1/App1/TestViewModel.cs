using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace App1
{
    internal class TestViewModel
    {
        public TestViewModel()
        {
            ObservableItems = new ObservableCollection<ItemListModel>();
        }

        public ObservableCollection<ItemListModel> ObservableItems { get; }

        public async Task Refresh()
        {
            var items = await DataSource.GetItemList();

            foreach (var item in items)
            {
                var od = ObservableItems.FirstOrDefault(i => i.Id == item.Id);
                if (od == null)
                {
                    ObservableItems.Add(item);
                }
                else
                {
                    if (od.Name != item.Name)
                    {
                        od.Name = item.Name;
                        od.OnPropertyChanged("Name");
                    }
                }
            }
        }
    }
}