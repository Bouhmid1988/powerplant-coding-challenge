using PowerPlantCodingChallenge.API.Models;
using PowerPlantCodingChallenge.API.Services;
using Xunit;

namespace PowerPlantCodingChallenge.Test;

public class GasPowerPlantCalculatorTests
{
    [Fact]
    [Trait("Category", "Calculate Cost Gas Power")]
    public void CalculateCost_Should_Return_Correct_Cost()
    {
        // Arrange

        const double expectedCost = 31.28;

        var fakePlant = new PowerPlant
        {
            Name = "gasfiredbig1",
            Type = PowerPlantType.GasFired,
            Efficiency = 0.53,
            Pmin = 100,
            Pmax = 460,
            Cost = 0
        };

        var fakeFuels = new Fuels
        {
            GasEuroMWh = 13.4,
            Co2EuroTon = 20
        };

        var calculator = new GasPowerPlantCalculator();
        var cost = calculator.CalculateCost(fakePlant, fakeFuels);

        // Assert

        Assert.Equal(expectedCost, cost, precision: 2);
    }

    [Theory]
    [Trait("Category", "Power Allocation Gas Power")]
    [InlineData("gasfiredbig1", 0.53, 100, 460, 13.4, 300, "gasfiredbig1", 300)]
    [InlineData("gasfiredbig1", 0.53, 100, 460, 13.4, 700, "gasfiredbig1", 460)]
    public void CalculatePowerAllocation_Should_Return_Correct_Power(
        string plantName, double efficiency, int pmin, int pmax, double gasEuroMWh,
        double load, string expectedName, double expectedPower)
    {
        // Arrange

        var fakePlant = new PowerPlant
        {
            Name = plantName,
            Type = PowerPlantType.GasFired,
            Efficiency = efficiency,
            Pmin = pmin,
            Pmax = pmax
        };
        var fakeFuels = new Fuels
        {
            GasEuroMWh = gasEuroMWh
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

        var calculator = new GasPowerPlantCalculator();

        // Act

        var allocationResponse = calculator.CalculatePowerAllocation(request, fakePlant);

        // Assert

        Assert.Equal(expectedName, allocationResponse.Name);
        Assert.Equal(expectedPower, allocationResponse.Power);
    }
}

