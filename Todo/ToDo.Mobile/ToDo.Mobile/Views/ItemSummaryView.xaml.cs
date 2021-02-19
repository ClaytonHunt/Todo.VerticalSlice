﻿using ToDo.Mobile.ViewModels;
using ToDo.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemSummaryView : ContentView
    {

        public ToDoItem Source { get; set; }

        public ItemSummaryView()
        {
            InitializeComponent();
        }
    }
}