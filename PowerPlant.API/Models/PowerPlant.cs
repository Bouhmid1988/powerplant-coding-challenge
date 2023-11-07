using System.Text.Json.Serialization;

namespace PowerPlantCodingChallenge.API.Models;
public class PowerPlant
{
    public required string Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required PowerPlantType Type { get; set; }
    public double Efficiency { get; set; }
    public int Pmin { get; set; }
    public int Pmax { get; set; }
    public double Cost { get; set; }
}
public enum PowerPlantType
{
    GasFired,
    TurboJet,
    WindTurbine
}

