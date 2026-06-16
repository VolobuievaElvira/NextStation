
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CarClass
{
    FirstClass,
    SecondClass
}