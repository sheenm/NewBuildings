using NewBuildings.Data.Objects;

namespace NewBuildings.BusinessLogic.ViewModels
{
    public class FlatFullInformationViewModel
    {
        public int Id { get; set; }
        public int RoomsCount {get;set;}
        public double FullArea { get; set; }
        public double KitchenArea { get; set; }
        public int Floor { get; set; }
        public decimal Cost { get; set; }

        public int ConstructionStage { get; set; }
        public string HousingNumber { get; set; }
        public string ResidentialComplexName { get; set; }

        public string DistrictName { get; set; }

        public string RegionName { get; set; }

        public FlatFullInformationViewModel()
        {
        }

        public FlatFullInformationViewModel(Flat flat)
        {
            Id = flat.Id;
            RoomsCount = flat.RoomsCount;
            FullArea = flat.FullArea;
            KitchenArea = flat.KitchenArea;
            Floor = flat.Floor;
            Cost = flat.Cost;

            ConstructionStage = flat.House.ConstructionStage;
            HousingNumber = flat.House.HousingNumber;
            ResidentialComplexName = flat.House.ResidentialComplexName;

            DistrictName = flat.District.Name;

            RegionName = flat.Region.Name;
        }
    }
}
