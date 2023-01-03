// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeripheralDeviceEmulator.Constants;

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

            KeyCode keyCode = KeyCode.None;
            try
            {
                keyCode = (KeyCode)((int)e.Key);
            }
            catch (Exception) { }

            textBox.Text = keyCode.ToString();
            e.Handled = true;

            textBox.IsEnabled = false;
            textBox.IsEnabled = true;
        }
    }
}
