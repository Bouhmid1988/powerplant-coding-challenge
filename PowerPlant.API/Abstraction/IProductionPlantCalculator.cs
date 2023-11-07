using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Abstraction;

/// <summary>
/// Define the   Production Plant Calculator Interface
/// </summary>
public interface IProductionPlantCalculator
{
    /// <summary>
    /// Calculate the Power Allocation
    /// </summary>
    /// <param name="productionPlantCalculationRequest"></param>
    /// <param name="powerPlant"></param>
    /// <returns>The task that represents the asynchronous operation</returns>
    PowerAllocationResponse CalculatePowerAllocation(ProductionPlantCalculationRequest productionPlantCalculationRequest, PowerPlant powerPlant);

    /// <summary>
    /// Calculate Cost
    /// </summary>
    /// <param name="plant"></param>
    /// <param name="fuels"></param>
    /// <returns>TThe calculated cost</returns>
    double CalculateCost(PowerPlant plant, Fuels fuels);
}

