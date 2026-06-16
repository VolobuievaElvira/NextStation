using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StationName
{
    SelectStation,
    Bolzano,
    Brenner,
    Franzensfeste,
    Innichen,
    Rovereto,
    Trento
}