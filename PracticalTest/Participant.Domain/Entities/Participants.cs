using Participant.Domain.Entities.Common;

namespace Participant.Domain.Entities
{
    public class Participants : BaseEntity
    {
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Address { get; set; }
        public int? EventID { get; set; }
        public string? EventDate { get; set; }
        public string? EventName { get; set; }
        public string? EventType { get; set; }
    }
}
