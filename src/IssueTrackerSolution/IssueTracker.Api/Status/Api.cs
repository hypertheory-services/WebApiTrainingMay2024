using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Status;

public class Api(ILogger<Api> logger) : ControllerBase
{
    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatus(CancellationToken token)
    {
        // Some real work here, that we have to await (it's going to be a database call, an API call, whatever.
        logger.LogInformation("Starting the Async Call");
        await Task.Delay(3000, token); // the API call, the database lookup, etc. 
        var response = new StatusResponseModel("Looks Good", DateTimeOffset.Now);
        logger.LogInformation("Finished The Call");
        return Ok(response);
    }
}


public record StatusResponseModel(string Message, DateTimeOffset CheckedAt);