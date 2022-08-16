namespace Participant.Domain.Services
{
    public class GetSportEventsParams
    {
        public int EventID { get; set; }
        public string Token { get; set; }
    }

    public class GetSportEventResults
    {
        public int? ID { get; set; }
        public string? EventDate { get; set; }
        public string? EventName { get; set; }
        public string? EventType { get; set; }
        public Organizer? Organizer { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
