using System.Windows;
using CoffeeBook.App.Pages;

namespace CoffeeBook.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationService.Navigate(new CoffeeNotesPage());
        }
    }
}
