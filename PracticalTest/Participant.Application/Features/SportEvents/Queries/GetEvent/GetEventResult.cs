namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventResult
    {
        public string? EventDate { get; set; }
        public string? EventName { get; set; }
        public string? EventType { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
