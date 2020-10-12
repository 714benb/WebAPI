using AutoMapper;
using WebAPI.API.Domain.Models;
using WebAPI.API.Resources;

namespace WebAPI.API.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<XEntity, XEntityResource>();
            CreateMap<YEntity, YEntityResource>();
        }
    }
}