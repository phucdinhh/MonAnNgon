using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.ViewModels
{
    public class ItemDetailPageModel
    {
        public ItemDetailViewModel ItemDetailViewModel { get; }
        public RelatedItemsViewModel RelatedItemsViewModel { get; }

        public ItemDetailPageModel()
        {
            ItemDetailViewModel = new ItemDetailViewModel();
            RelatedItemsViewModel = new RelatedItemsViewModel();
        }
    }
}
