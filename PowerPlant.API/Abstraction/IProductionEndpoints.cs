using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Abstraction;

/// <summary>
/// Define the  Production Endpoints Interface
/// </summary>
public interface IProductionEndpoints
{
    /// <summary>
    /// Calculate the Power Allocation
    /// </summary>
    /// <param name="productionPlantCalculationRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The task that represents the asynchronous operation</returns>
    Task<List<PowerAllocationResponse>> CalculatePowerAllocationAsync(ProductionPlantCalculationRequest productionPlantCalculationRequest, CancellationToken cancellationToken);
}

