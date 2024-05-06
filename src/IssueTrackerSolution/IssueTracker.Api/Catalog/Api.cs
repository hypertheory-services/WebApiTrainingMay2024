using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Catalog;

public class Api(IValidator<CreateCatalogItemRequest> validator, IDocumentSession session) : ControllerBase
{

    [HttpGet("/catalog")]
    public async Task<ActionResult> GetAllCatalogItemsAsync(CancellationToken token)
    {
        var data = await session.Query<CatalogItem>()
             .Select(c => new CatalogItemResponse(c.Id, c.Title, c.Description))
            .ToListAsync(token);
        return Ok(new { data });
    }

    [HttpPost("/catalog")]
    public async Task<ActionResult> AddACatalogItemAsync(
        [FromBody] CreateCatalogItemRequest request,
        CancellationToken token)
    {
        var validation = await validator.ValidateAsync(request, token);
        if (!validation.IsValid)
        {
            return this.CreateProblemDetailsForModelValidation("Cannot Add Catalog Item", validation.ToDictionary());
        }

        var entityToSave = new CatalogItem(Guid.NewGuid(), request.Title, request.Description, "todo", DateTimeOffset.Now);
        session.Store(entityToSave);
        await session.SaveChangesAsync(); // Do the actual work!


        var response = new CatalogItemResponse(entityToSave.Id, request.Title, request.Description);
        return Ok(response); // I have stored this thing in such a way that you can get it again, it is now
        // part of this collection. 
    }
}

