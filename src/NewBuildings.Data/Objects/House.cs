using Dapper;
using System;

namespace NewBuildings.Data.Objects
{
    [Table("Houses")]
    public class House : IBusinessObject
    {
        public Guid Id { get; set; }
        public int ConstructionStage { get; set; }
        public int HousingNumber { get; set; }
        public string ResidentialComplexName { get; set; }
        [Column("IdDistrict")]
        public Guid DistrictId { get; set; }
    }
}
