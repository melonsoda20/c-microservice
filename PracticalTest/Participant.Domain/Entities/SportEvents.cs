namespace Participant.Domain.Entities
{
    public class SportEvents
    {
        public int? ID { get; set; }
        public string? EventDate { get; set; }
        public string? EventName { get; set; }
        public string? EventType { get; set; }
        public Organizer? Organizer { get; set; }
    }
}
