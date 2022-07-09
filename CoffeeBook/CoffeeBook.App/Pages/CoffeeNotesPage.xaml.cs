using CoffeeBook.Domain.Entities;
using CoffeeBook.Persistence;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            IBaseService<Coffee> coffeeService = new BaseService<Coffee>(new AppDbContextFactory());

            var viewModel = new CoffeeNotesPageViewModel(baseService, coffeeService);
            viewModel.GetAllNotes();
            viewModel.GetAllCoffees();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Button_Note_Details(object sender, RoutedEventArgs e)
        {
            var myvalue = ((Button)sender).Tag;
            CoffeeNoteDetailsPage coffeeNoteDetailsPage = new CoffeeNoteDetailsPage((int)myvalue);
            NavigationService navigationService = this.NavigationService;
            navigationService.Navigate(coffeeNoteDetailsPage);
        }
    }
}
