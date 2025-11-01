using AIssist.Domain.Entities;
using AIssist.Domain.Http.Response.Log;
using AutoMapper;

namespace AIssist.Infrastructure.Ioc.Configs.AutoMap
{
	public class MappingLog : Profile
	{
		public MappingLog()
		{
            CreateMap<Logs, LogResponse>()
            .ForMember(p => p.Action, o => o.MapFrom(p => p.Action))
            .ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
            .ForMember(p => p.Created_At, o => o.MapFrom(p => p.CreatedAt));
        }
	}
}

