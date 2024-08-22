using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CommandController : ControllerBase
{
    private readonly IMainManager _mainManager;

    public CommandController(IMainManager mainManager)
    {
        _mainManager = mainManager;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CancellationToken cancellationToken)
    {
        await _mainManager.StartAsync(cancellationToken);
        return Ok();
    }

    [HttpPost("/publish")]
    public async Task<IActionResult> PublishAsync(CancellationToken cancellationToken)
    {
        await _mainManager.PublishPostsAsync(cancellationToken);
        return Ok();
    }
}