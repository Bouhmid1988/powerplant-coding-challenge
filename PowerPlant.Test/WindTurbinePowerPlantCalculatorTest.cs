using PowerPlantCodingChallenge.API.Models;
using PowerPlantCodingChallenge.API.Services;
using Xunit;

namespace PowerPlantCodingChallenge.Test;

public class WindTurbinePowerPlantCalculatorTest
{
    [Theory]
    [Trait("Category", "Power Allocation Wind Power")]
    [InlineData("windpark1", 1, 0, 150, 60, 80, "windpark1", 80)]
    [InlineData("windpark2", 1, 0, 36, 60, 100, "windpark2", 21.6)]
    
    public void CalculatePowerAllocation_Should_Return_Correct_Power(
        string plantName, double efficiency, int pmin, int pmax, int windPercentage,
        double load, string expectedName, double expectedPower)
    {
        // Arrange

        var fakePlant = new PowerPlant
        {
            Name = plantName,
            Type = PowerPlantType.WindTurbine,
            Efficiency = efficiency,
            Pmin = pmin,
            Pmax = pmax
        };

        var fakeFuels = new Fuels
        {
            WindPercentage = windPercentage
        };

        var fakePowerPlants = new List<PowerPlant>
            {
                fakePlant
            };

        var request = new ProductionPlantCalculationRequest
        {
            Load = load,
            Fuels = fakeFuels,
            PowerPlants = fakePowerPlants
        };

        var calculator = new WindTurbinePowerPlantCalculator();

        // Act

        var allocationResponse = calculator.CalculatePowerAllocation(request, fakePlant);

        // Assert
        Assert.Equal(expectedName, allocationResponse.Name);
        Assert.Equal(expectedPower, allocationResponse.Power);
    }
}

