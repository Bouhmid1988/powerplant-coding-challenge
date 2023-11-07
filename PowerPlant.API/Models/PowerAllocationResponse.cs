using System.Text.Json.Serialization;

namespace PowerPlantCodingChallenge.API.Models;

public class PowerAllocationResponse
{
    public string? Name { get; set; }

    [JsonPropertyName("P")]
    public double Power { get; set; }
}

