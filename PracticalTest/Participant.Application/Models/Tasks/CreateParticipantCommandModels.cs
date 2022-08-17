namespace Participant.Application.Models.Tasks
{
    public class CreateParticipantCommandRequest
    {
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Address { get; set; }
        public int EventID { get; set; }
        public string? Token { get; set; }
    }

    public class CreateParticipantCommandResponse
    {
        public bool IsValid { get; set; }
    }
}
