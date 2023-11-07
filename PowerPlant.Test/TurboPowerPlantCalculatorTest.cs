using PowerPlantCodingChallenge.API.Models;
using PowerPlantCodingChallenge.API.Services;
using Xunit;


namespace PowerPlantCodingChallenge.Test;

public class TurboPowerPlantCalculatorTest
{
    [Fact]
    [Trait("Category", "Calculate Cost Turbo Power")]
    public void CalculateCost_Should_Return_Correct_Cost()
    {
        // Arrange

        const double expectedCost = 169.33;
        var fakePlant = new PowerPlant
        {
            Name = "tj1",
            Type = PowerPlantType.TurboJet,
            Efficiency = 0.3,
            Pmin = 0,
            Pmax = 16
        };

        var fakeFuels = new Fuels
        {
            KerosineEuroMWh = 50.8
        };

        var calculator = new TurboPowerPlantCalculator();

        // Act

        var cost = calculator.CalculateCost(fakePlant, fakeFuels);
        
        // Assert

        Assert.Equal(expectedCost, cost, precision: 2);
    }

    [Fact]
    [Trait("Category", "Power Allocation Turbo Power")]
    public void CalculatePowerAllocation_Should_Return_Correct_Power()
    {
        // Arrange
        
        var fakePlant = new PowerPlant
        {
            Name = "tj1",
            Type = PowerPlantType.TurboJet,
            Efficiency = 0.3,
            Pmin = 0,
            Pmax = 16
        };
        var mockFuels = new Fuels
        {
            // Example  kerosine
            KerosineEuroMWh = 50.8
        };
        var fakePowerPlants = new List<PowerPlant>
            {
                fakePlant
            };

        var request = new ProductionPlantCalculationRequest
        {
            Load = 300,
            Fuels = mockFuels,
            PowerPlants = fakePowerPlants
        };

        var calculator = new TurboPowerPlantCalculator();

        // Act

        var allocationResponse = calculator.CalculatePowerAllocation(request, fakePlant);

        // Assert

        Assert.Equal("tj1", allocationResponse.Name);
        Assert.Equal(16, allocationResponse.Power);
    }
}


