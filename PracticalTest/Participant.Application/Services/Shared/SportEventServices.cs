using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Models.Services.Shared;
using static Participant.Application.Constants.Constants;

namespace Participant.Application.Services.Shared
{
    public class SportEventServices : ISportEventServices
    {
        private readonly IConfiguration _configuration;
        private string eventAPIBaseURL = "";
        private readonly IAPIServices _apiServices;

        public SportEventServices(
            IConfiguration configuration,
            IAPIServices apiServices
        )
        {
            _configuration = configuration;
            _apiServices = apiServices;
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
            var getAPIParams = new GetAPIParams(apiURL, eventsParams.Token);

            var response = await _apiServices.GetAPI(getAPIParams);

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
    }
}
