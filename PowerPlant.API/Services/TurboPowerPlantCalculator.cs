using PowerPlantCodingChallenge.API.Abstraction;
using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Services;

/// <summary>
/// Represents a service for Turbo Power Plant Calculator
/// </summary>
public class TurboPowerPlantCalculator : IProductionPlantCalculator
{
    /// <inheritdoc cref="IProductionPlantCalculator.CalculateCost"/>
    public double CalculateCost(PowerPlant plant, Fuels fuels) => fuels.KerosineEuroMWh / plant.Efficiency;

    /// <inheritdoc cref="IProductionPlantCalculator.CalculatePowerAllocation"/>
    public PowerAllocationResponse CalculatePowerAllocation(
        ProductionPlantCalculationRequest productionPlantCalculationRequest, PowerPlant powerPlant)
    {
        var powerLoad = productionPlantCalculationRequest.Load;

        if (powerLoad < powerPlant.Pmin)
            return new PowerAllocationResponse { Name = powerPlant.Name, Power = powerLoad };
        var power = powerPlant.Pmax > powerLoad ? powerLoad : powerPlant.Pmax;

        return new PowerAllocationResponse { Name = powerPlant.Name, Power = power };
    }
}

