using System.Text.Json;

namespace DestinyHaven.GenericModels
{
    public static class SessionObject
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            string json = JsonSerializer.Serialize<T>(value);  //gelen Product verisini json ' çevirdik
            session.SetString(key, json);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string json = session.GetString(key);  //elimizdeki string tipinde json formatlı datayı çağırdık

            return json == null ? default(T) : JsonSerializer.Deserialize<T>(json); // string json verisini json a çevirdik
        }
    }
}
