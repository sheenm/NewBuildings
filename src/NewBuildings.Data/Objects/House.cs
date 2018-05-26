using Dapper;

namespace NewBuildings.Data.Objects
{
    [Table("Houses")]
    public class House : IBusinessObject
    {
        public int Id { get; set; }
        public int ConstructionStage { get; set; }
        public string HousingNumber { get; set; }
        public string ResidentialComplexName { get; set; }
        [Column("IdDistrict")]
        public int DistrictId { get; set; }
    }
}
