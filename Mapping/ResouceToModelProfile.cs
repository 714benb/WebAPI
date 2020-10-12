using AutoMapper;
using WebAPI.API.Domain.Models;
using WebAPI.API.Resources;

namespace WebAPI.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveXEntityResource, XEntity>();
            CreateMap<SaveYEntityResource, YEntity>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(
                    src => (EUnitOfMeasurement) src.UnitOfMeasurement));
        }
    }
}