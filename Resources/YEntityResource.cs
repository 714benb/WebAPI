using WebAPI.API.Domain.Models;

namespace WebAPI.API.Resources
{
    public class YEntityResource
    {
        public int Id {get;set;}
        public string Name {get; set;}
        public short QuantityInPackage {get; set;}
        public EUnitOfMeasurement UnitOfMeasurement {get; set;}
        public XEntityResource XEntity { get; set; }
    }
}