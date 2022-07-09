using System.Windows.Controls;
using CoffeeBook.Domain.Entities;
using CoffeeBook.Persistence;
using CoffeeBook.Persistence.Services;
using CoffeeBook.Persistence.ViewModels.Pages;

namespace CoffeeBook.App.Pages
{
    /// <summary>
    /// Interaction logic for CoffeeNoteDetailsPage.xaml
    /// </summary>
    public partial class CoffeeNoteDetailsPage : Page
    {
        public CoffeeNoteDetailsPage(int noteId)
        {
            IBaseService<Note> noteService = new BaseService<Note>(new AppDbContextFactory());
            IBaseService<Coffee> coffeeService = new BaseService<Coffee>(new AppDbContextFactory());

            var viewModel = new CoffeeNoteDetailsPageViewModel(noteService);
            viewModel.GetNoteDetails(noteId);
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
