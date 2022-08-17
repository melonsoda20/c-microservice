namespace Participant.Application.Models.Services.Shared
{
    public class GetAPIParams
    {
        public string? RequestURL { get; set; }
        public string? AuthorizationHeader { get; set; }

        public GetAPIParams(string url, string token)
        {
            RequestURL = url;
            AuthorizationHeader = token;
        }
    }
}
