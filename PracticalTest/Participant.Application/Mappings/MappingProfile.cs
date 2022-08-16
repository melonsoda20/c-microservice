using AutoMapper;
using Participant.Application.Features.Participants.Commands.CreateParticipant;
using Participant.Application.Features.SportEvents.Queries.GetEvent;
using Participant.Domain.Entities;
using Participant.Domain.Services;

namespace Participant.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region CreateParticipant
            CreateMap<CreateParticipantCommand, GetEventQuery>().ReverseMap();
            CreateMap<CreateParticipantCommand, Participants>().ReverseMap();
            #endregion

            #region GetEvent
            CreateMap<GetEventResult, Participants>().ReverseMap();
            CreateMap<GetEventQuery, GetSportEventsParams>().ReverseMap();
            CreateMap<GetSportEventResults, GetEventResult>().ReverseMap();
            #endregion
        }
    }
}
