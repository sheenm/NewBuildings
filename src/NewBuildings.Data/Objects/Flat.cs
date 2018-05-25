using Dapper;
using System;

namespace NewBuildings.Data.Objects
{
    [Table("Flats")]
    public class Flat : IBusinessObject
    {
        public Guid Id { get; set; }
        [Column("IdHouse")]
        public Guid HouseId { get; set; }
        public int RoomsCount { get; set; }
        public int FullArea { get; set; }
        public int KitchenArea { get; set; }
        public int Floor { get; set; }
        public decimal Cost { get; set; }

        public House House { get; set; }
    }
}
