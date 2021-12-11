using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonAnNgon.Models;
using System.Collections.ObjectModel;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public ObservableCollection<food> ItemsLayout { get; set; }

        public HomePage()
        {
            InitializeComponent();
            ItemsLayout = new ObservableCollection<food>
            {
                new food { id = "1", name = "Bánh", img = "CanhThinhDuDu.jpg" },
                new food { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new food { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new food { id = "4", name = "Kho", img = "salad.jpg" },
                new food { id = "4", name = "Kho", img = "salad.jpg" },
                new food { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new food { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new food { id = "4", name = "Kho", img = "salad.jpg" },
            };
            BindingContext = this;
        }
    }
}