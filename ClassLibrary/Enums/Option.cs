using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Option
{
    RestaurantCar,
    BicycleTransport,
    PetTransport
}