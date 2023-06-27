using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Utilites.Helpers;

public class JsonHelper
{
    public static JObject FromJson(string json)
    {
        return JsonConvert.DeserializeObject<JObject>(json)!;
    }
}