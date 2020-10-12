namespace Supermarket.API.Domain.Models
{
    public class YEntity
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public short QuantityInPackage {get; set;}
        public EUnitOfMeasurement UnitOfMeasurement {get; set;}
        public int XEntityId {get; set;}
        public XEntity XEntity{get; set;}
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} XEntityId {XEntityId}";
        }
    }
}