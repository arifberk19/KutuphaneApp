using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Text.Json;
namespace Kutuphane.WebUI.Helper.SessionHelper
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object? value)
        {
            var x = JsonSerializer.Serialize(value, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            });
           
            session.SetString(key, x);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            
            return value==null?default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
