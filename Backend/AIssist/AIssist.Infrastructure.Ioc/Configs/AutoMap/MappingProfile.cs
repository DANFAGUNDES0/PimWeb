using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Profile;
using AutoMapper;

namespace AIssist.Infrastructure.Ioc.Configs.AutoMap
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProfileRequest, Profiles>()
            .ForMember(p => p.ProfileName, o => o.MapFrom(p => p.Profile))
            .ForMember(p => p.UpdatedAt, o => o.MapFrom(p => DateTime.Now))
            .ForMember(p => p.CreatedAt, o => o.MapFrom(p => DateTime.Now))
            .ForMember(p => p.Active, o => o.MapFrom(p => true))
            .ForMember(p => p.CreatedBy, o => o.MapFrom(p => p.Username))
            .ForMember(p => p.UpdatedBy, o => o.MapFrom(p => p.Username));

            CreateMap<ProfilePutRequest, Profiles>()
            .ForMember(p => p.ProfileName, o => o.MapFrom(p => p.ProfileName))
            .ForMember(p => p.UpdatedAt, o => o.MapFrom(p => DateTime.Now))
            .ForMember(p => p.Active, o => o.MapFrom(p => p.Active))
            .ForMember(p => p.UpdatedBy, o => o.MapFrom(p => p.Username));
        }
    }
}

