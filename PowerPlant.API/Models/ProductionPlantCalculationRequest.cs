namespace PowerPlantCodingChallenge.API.Models;

public class ProductionPlantCalculationRequest
{
    public required double Load { get; set; }
    public required Fuels Fuels { get; set; }
    public required List<PowerPlant> PowerPlants { get; set; }
}

