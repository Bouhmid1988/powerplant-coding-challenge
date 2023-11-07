using PowerPlantCodingChallenge.API.Abstraction;
using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Services;

/// <summary>
/// Represents a service for Wind Turbine Power Plant Calculator
/// </summary>
public class WindTurbinePowerPlantCalculator : IProductionPlantCalculator
{
    /// <inheritdoc cref="IProductionPlantCalculator.CalculateCost"/>
    public double CalculateCost(PowerPlant plant, Fuels fuels) => 0;

    /// <inheritdoc cref="IProductionPlantCalculator.CalculatePowerAllocation"/>
    public PowerAllocationResponse CalculatePowerAllocation(ProductionPlantCalculationRequest productionPlantCalculationRequest, PowerPlant powerPlant)
    {
        var result = productionPlantCalculationRequest.Fuels.WindPercentage * powerPlant.Pmax / 100.0;
        return new PowerAllocationResponse { Name = powerPlant.Name, Power = productionPlantCalculationRequest.Load > result ? result : productionPlantCalculationRequest.Load };
    }
}

