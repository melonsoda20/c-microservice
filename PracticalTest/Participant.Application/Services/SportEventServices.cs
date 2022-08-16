using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Participant.Application.Contracts.Services;
using Participant.Domain.Services;
using static Participant.Application.Constants.Constants;

namespace Participant.Application.Services
{
    public class SportEventServices : ISportEventServices
    {
        private readonly IConfiguration _configuration;
        private string eventAPIBaseURL = "";

        public SportEventServices(IConfiguration configuration)
        {
            _configuration = configuration;
            eventAPIBaseURL = _configuration[AppSettingsKey.EVENT_API_BASE_URL_KEY];
        }

        public async Task<GetSportEventResults> GetEvent(GetSportEventsParams eventsParams)
        {
            if (string.IsNullOrEmpty(eventAPIBaseURL))
            {
                return new GetSportEventResults
                {
                    IsError = true,
                    ErrorMessage = "Can't detect API URL"
                };
            }
            string apiURL = $"{eventAPIBaseURL}/sport-events/{eventsParams.EventID}";
            var response = await GetAPI(apiURL, eventsParams.Token);
            
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetSportEventResults>(responseMessage) ?? new GetSportEventResults
                {
                    IsError = true,
                    ErrorMessage = "Can't deserialize response"
                };
            }

            return new GetSportEventResults
            {
                IsError = true,
                ErrorMessage = response.Content.ToString()
            };
        }

        private async Task<HttpResponseMessage> GetAPI(string apiURL, string? token = null)
        {
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            return await client.GetAsync(apiURL);
        }
    }
}
