using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using App1.Annotations;

namespace App1
{
    public class ItemListModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine($"ItemListModel:ID[{Id}] - {propertyName} has changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}