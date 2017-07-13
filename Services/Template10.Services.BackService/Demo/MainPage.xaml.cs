using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Template10.Services.BackButtonService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackServiceDemoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEvent args)
        {
            ShellVisible = true;
            var service = BackButtonService.Instance; 
            service.BeforeBackRequested += (s, e) => MyListView.Items.Insert(0, "Before Back Requested");
            service.BackRequested += (s, e) => MyListView.Items.Insert(0, "Back Requested");
            service.BeforeForwardRequested += (s, e) => MyListView.Items.Insert(0, "Before Forward Requested");
            service.ForwardRequested += (s, e) => MyListView.Items.Insert(0, "Forward Requested");
            service.BackButtonUpdated += (s, e) => MyListView.Items.Insert(0, "Back button updated"); 
        }
        
        public bool ShellVisible
        {
            get { return (bool)GetValue(ShellVisibleProperty); }
            set { SetValue(ShellVisibleProperty, value); }
        }
        public static readonly DependencyProperty ShellVisibleProperty =
            DependencyProperty.Register(nameof(ShellVisible), typeof(bool), 
                typeof(MainPage), new PropertyMetadata(false, ShellVisibleChanged));
        private static void ShellVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var b = (bool)e.NewValue;
            Template10.Services.BackButtonService.Settings.ShowShellBackButton = b; // "hmmm" - Jerry Nixon
        }
    }
}
