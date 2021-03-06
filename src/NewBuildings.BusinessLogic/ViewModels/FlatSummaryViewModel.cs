﻿using NewBuildings.Data.Objects;

namespace NewBuildings.BusinessLogic.ViewModels
{
    public class FlatSummaryViewModel
    {
        public int Id { get; set; }
        public string ResidentialComplexName { get; set; }
        public int RoomCount { get; set; }
        public double FullArea { get; set; }
        public double KitchenArea { get; set; }
        public int Floor { get; set; }
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
            Floor = flat.Floor;
            Cost = flat.Cost;
        }
    }
}
