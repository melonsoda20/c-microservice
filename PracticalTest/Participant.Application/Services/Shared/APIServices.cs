using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Models.Services.Shared;

namespace Participant.Application.Services.Shared
{
    public class APIServices : IAPIServices
    {
        public async Task<HttpResponseMessage> GetAPI(GetAPIParams getParams)
        {
            HttpClient client = new();
            if (!string.IsNullOrEmpty(getParams.AuthorizationHeader))
            {
                client.DefaultRequestHeaders.Add("Authorization", getParams.AuthorizationHeader);
            }
            return await client.GetAsync(getParams.RequestURL);
        }
    }
}
