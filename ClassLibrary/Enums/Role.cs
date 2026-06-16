using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    TrainOperator,
    Conductor,
    NetworkManager,
    StationManager
}