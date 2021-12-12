using MonAnNgon.Models;
using MonAnNgon.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Food Food { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}