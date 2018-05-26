using Dapper;

namespace NewBuildings.Data.Objects
{
    [Table("Districts")]
    public class District : IBusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("IdRegion")]
        public int RegionId { get; set; }
    }
}
