using CoffeeBook.Domain.Enums;

namespace CoffeeBook.Domain.Entities
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }
        public virtual Origin Origin { get; set; }
        public int RoasterId { get; set; }
        public virtual Roaster Roaster { get; set; }
        public string Variety { get; set; }
        public MachiningProcessEnum MachiningProcess { get; set; }
        public BeansTypeEnum Type { get; set; }
        public DateTime RoastingDate { get; set; }
    }
}
