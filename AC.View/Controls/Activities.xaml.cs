// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PeripheralDeviceEmulator.Constants;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AC.View.Controls
{
    public sealed partial class Activities : UserControl
    {
        public Activities()
        {
            this.InitializeComponent();
        }

        private void KeyCodeTextbox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
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
