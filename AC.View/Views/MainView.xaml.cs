// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using AC.Model.Models;
using AC.View.Utilities.Services;
using AC.ViewModel.ViewModels;
using Microsoft.UI.Xaml;

namespace AC.View.Views
{
    public sealed partial class MainView : Window
    {
        public MainViewModel MainViewModel { get; }

        public MainView()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);

            MainViewGrid.Loaded += MainViewGrid_Loaded;
            MainViewGrid.IsHitTestVisible = false;

            AutoClicker autoClicker = new();
            DialogService dialogService = new(Content.XamlRoot);
            MainViewModel = new MainViewModel(autoClicker, dialogService);
        }

        private void MainViewGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DialogService dialogService = new(Content.XamlRoot);
            MainViewModel.DialogService = dialogService;
            MainViewGrid.IsHitTestVisible = true;
        }
    }
}
