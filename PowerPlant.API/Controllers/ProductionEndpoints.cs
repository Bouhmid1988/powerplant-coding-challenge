using Microsoft.AspNetCore.Mvc;
using PowerPlantCodingChallenge.API.Abstraction;
using PowerPlantCodingChallenge.API.Models;

namespace PowerPlantCodingChallenge.API.Controllers;

public static class ProductionEndpoints
{
    public static WebApplication MapProductionEndpoints(this WebApplication app)
    {
        var mapGroup = app.MapGroup("/productionplan").WithTags("Production Plan");
        mapGroup.MapPost("", async ([FromBody] ProductionPlantCalculationRequest payload, [FromServices] IProductionEndpoints calculator, CancellationToken cancellationToken) =>
        {
            var results = await calculator.CalculatePowerAllocationAsync(payload, cancellationToken);
            return Results.Ok(results);
        });
        return app;
    }
}

