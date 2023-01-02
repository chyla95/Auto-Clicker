// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AC.View.Views
{
    public sealed partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);
        }

        private void KeyCodeTextbox_PreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            bool isNumeric = int.TryParse(e.Key.ToString(), out _);

            if (isNumeric) {
                textBox.Text = "Invalid Key!";
                e.Handled = true;
                return;
            }
            else
            {
                textBox.Text = e.Key.ToString();
                e.Handled = true;
                return;
            }
        }
    }
}
