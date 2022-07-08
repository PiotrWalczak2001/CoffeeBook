using System.Linq;
using CoffeeBook.App.Windows;
using CoffeeBook.Persistence;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using CoffeeBook.Domain.Entities;

namespace CoffeeBook.App.Pages
{
    /// <summary>
    /// Interaction logic for CoffeeNotesPage.xaml
    /// </summary>
    public partial class CoffeeNotesPage : Page
    {
        public CoffeeNotesPage()
        {
            IBaseService<Note> baseService = new BaseService<Note>(new AppDbContextFactory());

            var viewModel = new CoffeeNotesPageViewModel(baseService);
            viewModel.GetAllNotes();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Button_Open_Coffee_Window(object sender, RoutedEventArgs e)
        {
            CoffeeEditWindow coffeEditWindow = new CoffeeEditWindow();
            
            coffeEditWindow.Show();
        }

    }
}
