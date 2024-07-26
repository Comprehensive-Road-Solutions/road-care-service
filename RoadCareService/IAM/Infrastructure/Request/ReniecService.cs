using System.Net.Http.Headers;
using System.Text.Json;
using RoadCareService.IAM.Application.Internal.OutboundServices;

namespace RoadCareService.IAM.Infrastructure.Request
{
    public class ReniecService
        (IConfiguration configuration) :
        IReniecService
    {
        public async Task<bool> ValidateDni
            (int dni)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                configuration["HttpClient:Reniec"]);

            var httpResponseMessage = await httpClient.GetAsync
                ("https://dniruc.apisperu.com/api/v1/dni/" + dni);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage
                    .Content.ReadAsStringAsync();

                var contentResult = JsonSerializer
                    .Deserialize<Dictionary
                    <string, JsonElement>>(result);

                if (contentResult != null &&
                    contentResult.TryGetValue
                    ("success", out var success))
                    return success.ValueKind == JsonValueKind.True;
            }

            return false;
        }
    }
}