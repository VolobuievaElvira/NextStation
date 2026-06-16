using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RouteType
{
    Fastest,
    Shortest,
    Cheapest,
    MostComfortable
}