using MediatR;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQuery : IRequest<GetEventResult>
    {
        public int ID { get; set; }
        public string Token { get; set; }
    }
}
