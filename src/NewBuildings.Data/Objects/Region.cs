using Dapper;

namespace NewBuildings.Data.Objects
{
    [Table("Regions")]
    public class Region : IBusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
