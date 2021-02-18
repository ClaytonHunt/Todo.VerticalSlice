using System;
using System.Collections.Generic;
using ToDo.Mobile.ViewModels;
using ToDo.Mobile.Views;
using Xamarin.Forms;

namespace ToDo.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
