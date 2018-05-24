using System;

namespace NewBuildings.BusinessLogic.Objects
{
    public class House : IBusinessObject
    {
        public Guid Id { get; set; }
        public int ConstructionStage { get; set; }
        public int HousingNumber { get; set; }
        public string ResidentialComplexName { get; set; }
        public Guid DistrictId { get; set; }
    }
}
