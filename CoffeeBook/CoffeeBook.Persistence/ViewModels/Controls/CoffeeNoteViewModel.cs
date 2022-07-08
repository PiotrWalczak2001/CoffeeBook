using CoffeeBook.Persistence.ViewModels.Base;

namespace CoffeeBook.Persistence.ViewModels.Controls
{
    public class CoffeeNoteViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
