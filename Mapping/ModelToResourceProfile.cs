using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using WebAPI.API.Domain.Models;
using WebAPI.API.Resources;
using WebAPI.API.Extensions;

namespace WebAPI.API.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<XEntity, XEntityResource>();
            CreateMap<YEntity, YEntityResource>()
                .ForMember(src => src.UnitOfMeasurement,
                    opt => opt.MapFrom(
                        src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}