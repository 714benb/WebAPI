using System.ComponentModel.DataAnnotations;
using WebAPI.API.Domain.Models;

namespace WebAPI.API.Resources
{
    public class SaveYEntityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name {get; set;}
        [Required]
        public short QuantityInPackage {get; set;}
        [Required]
        public EUnitOfMeasurement UnitOfMeasurement {get; set;}
        [Required]
        public int XEntityId {get; set;}
    }
}