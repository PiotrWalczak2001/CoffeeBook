using CoffeeBook.Domain.Enums;
using CoffeeBook.Persistence.ViewModels.Base;

namespace CoffeeBook.Persistence.ViewModels.Controls
{
    public class CoffeeNoteViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
        public int CoffeeId { get; set; }
        public BrewingTypeEnum BrewingType { get; set; }
        public DateTime BrewedDate { get; set; }
        public DateTime BrewingTime { get; set; }
    }
}
