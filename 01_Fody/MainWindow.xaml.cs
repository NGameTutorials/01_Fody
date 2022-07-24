using _01_Fody.Views;
using System;
using System.Windows;

namespace _01_Fody
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void ShowWindow(Type windowType)
        {
            var window = Activator.CreateInstance(windowType);
            if (window is Window targetWindow)
                targetWindow.ShowDialog();
        }

        private void BasicMVVM(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(_01_MVVMWithoutFody));
        }

        private void BasicMVVMFody(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(_02_MVVMWithFody));
        }

        private void MoreAdvancedMVVM(object sender, RoutedEventArgs e)
        {

        }

        private void MoreAdvancedMVVMFody(object sender, RoutedEventArgs e)
        {

        }
    }
}
