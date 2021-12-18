using MonAnNgon.ViewModels;
using MonAnNgon.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonAnNgon
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.ItemDetailPage), typeof(Views.ItemDetailPage));
            Routing.RegisterRoute(nameof(Views.FoodsPage), typeof(Views.FoodsPage));
        }

        private async void OnShareItemClicked(object sender, EventArgs e)
        {
            string uri = Device.RuntimePlatform == Device.Android
                ? "https://play.google.com/store/apps/details?id=com.v3.cookbook"
                : "https://itunes.apple.com/";
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = "Tải ứng dụng tại đây: "
            });
        }
    
        private async void OnRatingItemClicked(object sender, EventArgs e)
        {
            string url = Device.RuntimePlatform == Device.Android
                ? "https://play.google.com/store/apps/details?id=com.v3.cookbook"
                : "https://itunes.apple.com/";
            await Browser.OpenAsync(url, BrowserLaunchMode.External);
        }
    }
}
