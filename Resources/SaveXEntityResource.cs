using System.ComponentModel.DataAnnotations;

namespace WebAPI.API.Resources
{
    public class SaveXEntityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name {get; set;}
    }
}