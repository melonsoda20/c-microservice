using MediatR;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQuery : IRequest<GetEventResult>
    {
        public int EventID { get; set; }
        public string Token { get; set; }
    }
}
