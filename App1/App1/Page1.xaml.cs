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
        internal TestViewModel _viewModel;

        internal Func<Task> RunAction { get; set; }
        public bool IsRunning { get; private set; }
        public bool IsActivated { get; private set; }

        public Page1()
        {
            _viewModel = new TestViewModel();
            IsRunning = true;
            IsActivated = false;
            BindingContext = _viewModel;
            InitializeComponent();
            ItemListView.ItemTemplate = new DataTemplate(typeof(ItemListCell));
            ItemListView.ItemsSource = _viewModel.ObservableItems;
            RunAction = Run;
        }

        public async Task Run()
        {
            while (true)
            {
                Debug.WriteLine("ProductionViewModel.Refreshing");
                await _viewModel.Refresh();
                await Task.Delay(5000);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await StartRefresh();
            Debug.WriteLine("Base.OnAppearing");
        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();
            StopRefresh();
            Debug.WriteLine("Base.OnDisappearing");
        }

        private async Task StartRefresh()
        {
            Debug.WriteLine("Base.RefreshStart");
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
            Debug.WriteLine("Base.RefreshStop");
            IsRunning = false;
        }
    }
}
