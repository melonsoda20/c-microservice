using AutoMapper;
using Participant.Application.Features.Participants.Commands.CreateParticipant;
using Participant.Application.Features.SportEvents.Queries.GetEvent;
using Participant.Application.Models.Tasks;
using Participant.Domain.Entities;
using Participant.Domain.Services;

namespace Participant.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region CreateParticipant
            CreateMap<CreateParticipantCommandRequest, GetEventQuery>().ReverseMap();
            CreateMap<CreateParticipantCommandRequest, Participants>().ReverseMap();
            CreateMap<CreateParticipantCommand, CreateParticipantCommandRequest>().ReverseMap();
            #endregion

            #region GetEvent
            CreateMap<GetEventResult, Participants>().ReverseMap();
            CreateMap<GetEventQueryParams, GetSportEventsParams>().ReverseMap();
            CreateMap<GetSportEventResults, GetEventQueryResponse>().ReverseMap();
            CreateMap<GetEventQuery, GetEventQueryParams>().ReverseMap();
            CreateMap<GetEventQueryResponse, GetEventResult>().ReverseMap();
            #endregion
        }
    }
}
