using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public static class DataSource
    {
        private static int _count;

        public static async Task<List<ItemListModel>> GetItemList()
        {
            _count++;

            var list = new List<ItemListModel>();

            await Task.Factory.StartNew(() =>
            {
                var dev1 = new ItemListModel
                {
                    Name = $"K160{_count}",
                    Id = new Guid("00000000-0000-0000-0000-000000000001")
                };

                var dev2 = new ItemListModel
                {
                    Name = "K2600",
                    Id = new Guid("00000000-0000-0000-0000-000000000002")
                };

                var dev3 = new ItemListModel
                {
                    Name = "K3600",
                    Id = new Guid("00000000-0000-0000-0000-000000000003")
                };

                var dev4 = new ItemListModel
                {
                    Name = "K5000",
                    Id = new Guid("00000000-0000-0000-0000-000000000004")
                };

                list.Add(dev1);
                list.Add(dev2);
                list.Add(dev3);
                list.Add(dev4);

                if (_count == 3)
                {
                    list.Add(new ItemListModel
                    {
                        Name = "K9999",
                        Id = new Guid("00000000-0000-0000-0000-000000000099")
                    });
                }
            });

            return list;
        }
    }
}
