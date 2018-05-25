using Dapper;
using System;

namespace NewBuildings.Data.Objects
{
    [Table("Regions")]
    public class Region : IBusinessObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
