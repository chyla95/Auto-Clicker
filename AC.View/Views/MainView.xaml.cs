// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Diagnostics;
using Microsoft.UI.Xaml;

namespace AC.View.Views
{
    public sealed partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            Debug.WriteLine(e.Key);
        }
    }
}
