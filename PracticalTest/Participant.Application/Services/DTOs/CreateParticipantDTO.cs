namespace Participant.Application.Services.DTOs
{
    public class CreateParticipantDTO
    {
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Address { get; set; }
        public int EventID { get; set; }
    }
}
