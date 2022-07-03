using CoffeeBook.Domain.Enums;

namespace CoffeeBook.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoffeeId { get; set; }
        public virtual Coffee Coffee { get; set; }
        public DateTime BrewedDate { get; set; }
        public BrewingTypeEnum BrewingTypeEnum { get; set; }
        public DateTime BrewingTime { get; set; }
    }
}
