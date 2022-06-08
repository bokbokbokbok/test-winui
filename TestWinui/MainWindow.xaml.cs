using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TestWinui
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            PageRedirect(addressBar.Text);
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                PageRedirect(addressBar.Text);
            }
        }

        private void PageRedirect(string url)
        {
            try
            {
                Uri targetUri = new Uri(url);
                MyWebView.Source = targetUri;
            }
            catch (FormatException ex)
            {
                ShowErrorPopup(url);
            }
        }

        private async void ShowErrorPopup(string url)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Incorrect url",
                Content = url + " url was not in the correct format. Please enter a correct url.",
                CloseButtonText = "Ok"
            };

            noWifiDialog.XamlRoot = HomeGrid.XamlRoot;
            await noWifiDialog.ShowAsync();
        }
    }
}
