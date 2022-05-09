using Newtonsoft.Json;

namespace TicketVerkoop.Extensions
{
    public static class SessionExtensions
    {
        // Extension methods, as the name suggests, are additional methods.Extension 
        //methods allow you to inject additional methods without modifying, deriving or 
        //recompiling the original class, struct or interface.

        public static void SetObjects(this ISession session, string key, object value)
        // alle extension methodes die je schrijft beginnen altijd met "this"
        // 2 parameters =>  naam van de "envelop" + het object dat wordt opgeslagen
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // Json object
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
