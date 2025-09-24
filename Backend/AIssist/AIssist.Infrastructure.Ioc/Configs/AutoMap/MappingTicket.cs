using AIssist.Domain.Entities;
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
				.ForMember(p => p.Reporter_Id, o => o.MapFrom(p => p.ReporterId))
				.ForMember(p => p.Root_Cause_id, o => o.MapFrom(p => p.RootCauseId))
                .ForMember(p => p.Status_id, o => o.MapFrom(p => Domain.Enums.Status.Aberto))
                .ForMember(p => p.Created_At, o => o.MapFrom(p => DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(p => p.Updated_At, o => o.MapFrom(p => DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(p => p.Ticket_Number, o => o.MapFrom(p => string.Concat("INC", Guid.NewGuid().ToString("N").Substring(0, 8))));

            CreateMap<Tickets, TicketResponse>()
                .ForMember(p => p.Id, o => o.MapFrom(p => p.Id))
                .ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
                .ForMember(p => p.Solution, o => o.MapFrom(p => p.Solution))
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => p.Ticket_Number))
                .ForMember(p => p.Status, o => o.MapFrom(p => EnumHelper.GetDescriptionFromValue<Domain.Enums.Status>(p.Status_id)))
                .ForMember(p => p.RootCauseId, o => o.MapFrom(p => p.Root_Cause_id))
                .ForMember(p => p.CreatedAt, o => o.MapFrom(p => p.Created_At))
                .ForMember(p => p.UpdatedAt, o => o.MapFrom(p => p.Updated_At))
                .ForMember(p => p.TicketNumber, o => o.MapFrom(p => p.Ticket_Number));

            CreateMap<TicketPutRequest, Tickets>()
                .ForMember(p => p.Ticket_Number, o => o.MapFrom(p => p.TicketNumber))
                .ForMember(p => p.Description, o => o.MapFrom(p => p.Description))
                .ForMember(p => p.Solution, o => o.MapFrom(p => p.Solution));
        }
	}
}

