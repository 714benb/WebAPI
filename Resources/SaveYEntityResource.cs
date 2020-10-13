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
        [Range(0,100)]
        public short QuantityInPackage {get; set;}
        [Required]
        [Range(1,5)]
        public int UnitOfMeasurement {get; set;}
        [Required]
        public int XEntityId {get; set;}
    }
}