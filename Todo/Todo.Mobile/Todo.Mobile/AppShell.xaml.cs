using System;
using System.Collections.Generic;
using Todo.Mobile.ViewModels;
using Todo.Mobile.Views;
using Xamarin.Forms;

namespace Todo.Mobile
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
