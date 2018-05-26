using Dapper;

namespace NewBuildings.Data.Objects
{
    [Table("Flats")]
    public class Flat : IBusinessObject
    {
        public int Id { get; set; }
        [Column("IdHouse")]
        public int HouseId { get; set; }
        public int RoomsCount { get; set; }
        public double FullArea { get; set; }
        public double KitchenArea { get; set; }
        public int Floor { get; set; }
        public decimal Cost { get; set; }

        public House House { get; set; }
        public District District { get; set; }
        public Region Region { get; set; }
    }
}
