using System;

namespace NewBuildings.BusinessLogic.Objects
{
    public class District : IBusinessObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RegionId { get; set; }
    }
}
