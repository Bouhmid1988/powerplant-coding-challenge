using PowerPlantCodingChallenge.API.Models;
using PowerPlantCodingChallenge.API.Services;
using Xunit;

namespace PowerPlantCodingChallenge.Test;

public class ProductionPlanCalculatorTest
{
    [Theory]
    [Trait("Category", "Calculate Power Allocation")]
    [InlineData("windpark1", PowerPlantType.WindTurbine, 1, 0, 150, 910, "windpark1", 90)]
    [InlineData("windpark2", PowerPlantType.WindTurbine, 1, 0, 36, 820, "windpark2", 21.6)]
    [InlineData("gasfiredbig1", PowerPlantType.GasFired, 0.53, 100, 460, 798.4, "gasfiredbig1", 460)]
    [InlineData("gasfiredbig2", PowerPlantType.GasFired, 0.53, 100, 460, 338.4, "gasfiredbig2", 338.4)]
    [InlineData("gasfiredsomewhatsmaller", PowerPlantType.GasFired, 0.37, 40, 210, 0, "gasfiredsomewhatsmaller", 0)]
    [InlineData("tj1", PowerPlantType.TurboJet, 0.3, 0, 16, 0, "tj1", 0)]
    public async Task CalculatePowerAllocationAsync_Should_Return_Correct_Allocation(
        string plantName, PowerPlantType plantType, double efficiency, int pmin, int pmax,
         double load, string expectedName, double expectedPower)
    {
        // Arrange

        var fakePlant = new PowerPlant
        {
            Name = plantName,
            Type = plantType,
            Efficiency = efficiency,
            Pmin = pmin,
            Pmax = pmax
        };

        var fakePowerPlants = new List<PowerPlant>
        {
            fakePlant
        };

        var fakeFuels = new Fuels
        {
            WindPercentage = 60,
            GasEuroMWh = 13.4,
            Co2EuroTon = 20,
            KerosineEuroMWh = 50.8

        };

        var request = new ProductionPlantCalculationRequest
        {
            PowerPlants = fakePowerPlants,
            Fuels = fakeFuels,
            Load = load
        };

        var calculator = new ProductionPlanCalculator();

        // Act

        var allocationResponseList = await calculator.CalculatePowerAllocationAsync(request, CancellationToken.None);

        // Assert

        Assert.Single(allocationResponseList);
        Assert.Equal(expectedName, allocationResponseList[0].Name);
        Assert.Equal(expectedPower, allocationResponseList[0].Power, precision: 2);
    }
}


