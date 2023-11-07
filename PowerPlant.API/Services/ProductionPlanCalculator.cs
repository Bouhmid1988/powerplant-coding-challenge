using PowerPlantCodingChallenge.API.Abstraction;
using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Services;

/// <summary>
/// Represents a service for Production Endpoints
/// </summary>
public class ProductionPlanCalculator : IProductionEndpoints
{
    /// <inheritdoc cref="IProductionEndpoints.CalculatePowerAllocationAsync"/>
    public Task<List<PowerAllocationResponse>> CalculatePowerAllocationAsync(ProductionPlantCalculationRequest productionPlantCalculationRequest, CancellationToken cancellationToken) =>
        Task.FromResult(productionPlantCalculationRequest.PowerPlants
            .Select(c => CalculateCost(c, productionPlantCalculationRequest.Fuels))
            .OrderBy(p => p.Cost)
            .Select(x => Calculate(productionPlantCalculationRequest, x))
            .ToList());

    /// <summary>
    /// Calculate Cost
    /// </summary>
    /// <param name="powerPlant"></param>
    /// <param name="fuels"></param>
    /// <returns>Calculate Cost </returns>
    private static PowerPlant CalculateCost(PowerPlant powerPlant, Fuels fuels)
    {
        var calculator = SetCalculatorByType(powerPlant);
        powerPlant.Cost = calculator.CalculateCost(powerPlant, fuels);
        return powerPlant;
    }

    /// <summary>
    /// Calculate Power Allocation 
    /// </summary>
    /// <param name="productionPlantCalculationRequest"></param>
    /// <param name="item"></param>
    /// <returns>Calculate Power Allocation by type plant </returns>
    private static PowerAllocationResponse Calculate(ProductionPlantCalculationRequest productionPlantCalculationRequest, PowerPlant item)
    {
        var calculator = SetCalculatorByType(item);
        var result = calculator.CalculatePowerAllocation(productionPlantCalculationRequest, item);
        var allocatedPower = result.Power;
        productionPlantCalculationRequest.Load -= allocatedPower;
        return result;
    }

    /// <summary>
    /// Set Calculator By Type plant
    /// </summary>
    /// <param name="powerPlant"></param>
    /// <returns> Set Calculator By Type plant </returns>
    private static IProductionPlantCalculator SetCalculatorByType(PowerPlant powerPlant) => powerPlant.Type switch
    {
        PowerPlantType.GasFired => new GasPowerPlantCalculator(),
        PowerPlantType.TurboJet => new TurboPowerPlantCalculator(),
        PowerPlantType.WindTurbine => new WindTurbinePowerPlantCalculator(),
        _ => throw new NotImplementedException($"Unknown power plant type {powerPlant.Type} ")
    };
}

