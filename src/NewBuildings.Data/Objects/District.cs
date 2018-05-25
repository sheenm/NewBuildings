using Dapper;
using System;

namespace NewBuildings.Data.Objects
{
    [Table("Districts")]
    public class District : IBusinessObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Column("IdRegion")]
        public Guid RegionId { get; set; }
    }
}
