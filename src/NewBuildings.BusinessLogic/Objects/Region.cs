using System;

namespace NewBuildings.BusinessLogic.Objects
{
    public class Region : IBusinessObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
