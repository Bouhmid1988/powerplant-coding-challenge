using PowerPlantCodingChallenge.API.Abstraction;
using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Services;

/// <summary>
/// Represents a service for Gas Power Plant Calculator
/// </summary>
public class GasPowerPlantCalculator : IProductionPlantCalculator
{
    /// <inheritdoc cref="IProductionPlantCalculator.CalculateCost"/>
    public double CalculateCost(PowerPlant plant, Fuels fuels)
        => fuels.GasEuroMWh / plant.Efficiency + 0.3 * fuels.Co2EuroTon;

    /// <inheritdoc cref="IProductionPlantCalculator.CalculatePowerAllocation"/>
    public PowerAllocationResponse CalculatePowerAllocation(ProductionPlantCalculationRequest productionPlantCalculationRequest, PowerPlant powerPlant)
    {
        var powerLoad = productionPlantCalculationRequest.Load;

        if (powerLoad < powerPlant.Pmin)
            return new PowerAllocationResponse { Name = powerPlant.Name, Power = 0.0 };
        var power = powerPlant.Pmax > powerLoad ? powerLoad : powerPlant.Pmax;
        return new PowerAllocationResponse { Name = powerPlant.Name, Power = power };
    }
}

