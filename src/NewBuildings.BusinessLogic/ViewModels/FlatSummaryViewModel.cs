using NewBuildings.Data.Objects;
using System;

namespace NewBuildings.BusinessLogic.ViewModels
{
    public class FlatSummaryViewModel
    {
        public Guid Id { get; set; }
        public string ResidentialComplexName { get; set; }
        public int RoomCount { get; set; }
        public int FullArea { get; set; }
        public int KitchenArea { get; set; }
        public decimal Cost { get; set; }

        public FlatSummaryViewModel()
        {
        }

        public FlatSummaryViewModel(Flat flat, House house)
        {
            Id = flat.Id;
            ResidentialComplexName = $"{house.ResidentialComplexName} оч.{house.ConstructionStage} к.{house.HousingNumber}";
            RoomCount = flat.RoomsCount;
            FullArea = flat.FullArea;
            KitchenArea = flat.KitchenArea;
            Cost = flat.Cost;
        }
    }
}
