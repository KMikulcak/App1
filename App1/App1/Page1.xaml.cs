using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page1 : ContentPage
    {
        internal TestViewModel ViewModel;

        internal Func<Task> RunAction { get; set; }
        public bool IsRunning { get; private set; }
        public bool IsActivated { get; private set; }

        public Page1()
        {
            Debug.WriteLine("Page1.Ctor");
            ViewModel = new TestViewModel();
            IsRunning = true;
            IsActivated = false;
            BindingContext = ViewModel;
            InitializeComponent();
            ItemListView.ItemTemplate = new DataTemplate(typeof(ItemListCell));
            ItemListView.ItemsSource = ViewModel.ObservableItems;
            RunAction = Run;
        }

        public async Task Run()
        {
            while (true)
            {
                Debug.WriteLine("Page1.Refreshing");
                await ViewModel.Refresh();
                await Task.Delay(5000);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await StartRefresh();
            Debug.WriteLine("Page1.OnAppearing");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopRefresh();
            Debug.WriteLine("Page1.OnDisappearing");
        }

        private async Task StartRefresh()
        {
            Debug.WriteLine("Page1.RefreshStart");
            IsRunning = true;
            if (IsActivated == false)
            {
                //                Device.BeginInvokeOnMainThread(async () =>
                //                {
                IsActivated = true;
                await RunAction();
                //                });
            }
        }

        internal void StopRefresh()
        {
            Debug.WriteLine("Page1.RefreshStop");
            IsRunning = false;
        }
    }
}
