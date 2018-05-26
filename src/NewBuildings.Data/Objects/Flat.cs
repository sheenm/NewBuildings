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
        public int FullArea { get; set; }
        public int KitchenArea { get; set; }
        public int Floor { get; set; }
        public decimal Cost { get; set; }

        public House House { get; set; }
    }
}
