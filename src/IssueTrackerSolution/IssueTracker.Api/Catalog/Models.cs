namespace IssueTracker.Api.Catalog;

// "Models" are the things that leave or arrive from outside our service boundary.
// they are C# types that will be deserialized or serialized from the json coming into our out of our api.

public record CreateCatalogItemRequest(string Title, string Description);

public record CatalogItemResponse(Guid Id, string Title, string Description);