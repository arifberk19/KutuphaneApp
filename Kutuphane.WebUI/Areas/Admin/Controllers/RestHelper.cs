using System.Security.Policy;
using System.Text.Json;
using RestSharp;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    public static class RestHelper
    {

        public static async Task<TOut?> PostRequestAsync<TIn, TOut>(string url, TIn entity, Method method = Method.Post)
        {
            using (var client = new RestClient())
            {
                var request = new RestRequest(url, method);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                var body = JsonSerializer.Serialize(entity);
                request.AddBody(body, "application/json");
                var resp = await client.ExecuteAsync(request);

                if (resp.IsSuccessStatusCode && !string.IsNullOrEmpty(resp.Content))
                {
                    return JsonSerializer.Deserialize<TOut>(resp.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return default;
            }
        }

        public static async Task<T?> GetRequestAsync<T>(string url)
        {
            using (var client = new RestClient())
            {
                var request = new RestRequest(url);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                var resp = await client.ExecuteAsync(request);
                if (resp.IsSuccessStatusCode && !string.IsNullOrEmpty(resp.Content))
                {
                    return JsonSerializer.Deserialize<T>(resp.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                    return default;
            }
        }
    }
}
