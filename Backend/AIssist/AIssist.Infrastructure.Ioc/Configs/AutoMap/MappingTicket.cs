﻿using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Ticket;
using AIssist.Domain.Http.Response.Tickets;
using AIssist.Shared.Helpers;
using AutoMapper;

namespace AIssist.Infrastructure.Ioc.Configs.AutoMap
{
	public class MappingTicket : Profile
	{
		public MappingTicket()
		{
			CreateMap<TicketPostRequest, Tickets>()
				.ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
				.ForMember(p => p.Solution, o => o.MapFrom(p => p.Solution))
				.ForMember(p => p.ReporterId, o => o.MapFrom(p => p.ReporterId))
				.ForMember(p => p.RootCauseId, o => o.MapFrom(p => p.RootCauseId))
                .ForMember(p => p.Status, o => o.MapFrom(p => Domain.Enums.TicketStatus.Aberto))
                .ForMember(p => p.CreatedAt, o => o.MapFrom(p => DateTime.Now))
                .ForMember(p => p.UpdatedAt, o => o.MapFrom(p => DateTime.Now))
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => string.Concat("INC", Guid.NewGuid().ToString("N").Substring(0, 8))));

            CreateMap<Tickets, TicketResponse>()
                .ForMember(p => p.Id, o => o.MapFrom(p => p.Id))
                .ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
                .ForMember(p => p.Solution, o => o.MapFrom(p => p.Solution))
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => p.TicketNumber))
                //.ForMember(p => p.Status, o => o.MapFrom(p => EnumHelper.GetDescriptionFromValue<Domain.Enums.TicketStatus>(p.Status)))
                .ForMember(p => p.RootCauseId, o => o.MapFrom(p => p.RootCauseId))
                .ForMember(p => p.CreatedAt, o => o.MapFrom(p => p.CreatedAt))
                .ForMember(p => p.UpdatedAt, o => o.MapFrom(p => p.UpdatedAt))
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => p.TicketNumber));

            CreateMap<TicketPutRequest, Tickets>()
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => p.TicketNumber))
                .ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
                .ForMember(p => p.Solution, o => o.MapFrom(p => p.Solution));
        }
	}
}

