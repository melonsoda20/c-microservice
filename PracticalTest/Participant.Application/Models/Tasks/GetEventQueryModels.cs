namespace Participant.Application.Models.Tasks
{
    public class GetEventQueryParams
    {
        public int EventID { get; set; }
        public string? Token { get; set; }
    }

    public class GetEventQueryResponse
    {
        public string? EventDate { get; set; }
        public string? EventName { get; set; }
        public string? EventType { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
