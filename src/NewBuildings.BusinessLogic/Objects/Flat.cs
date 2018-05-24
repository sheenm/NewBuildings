using System;

namespace NewBuildings.BusinessLogic.Objects
{
    public class Flat : IBusinessObject
    {
        public Guid Id { get; set; }
        public Guid HouseId { get; set; }
        public int RoomsCount { get; set; }
        public int FullArea { get; set; }
        public int KitchenArea { get; set; }
        public int Floor { get; set; }
        public decimal Cost { get; set; }
    }
}
