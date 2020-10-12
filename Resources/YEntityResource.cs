using Supermarket.API.Domain.Models;

namespace Supermarket.API.Resources
{
    public class YEntityResource
    {
        public int Id {get;set;}
        public string Name {get; set;}
        public short QuantityInPackage {get; set;}
        public EUnitOfMeasurement UnitOfMeasurement {get; set;}
        public int XEntityId {get; set;}
    }
}