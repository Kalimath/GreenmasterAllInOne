using Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Features.Blooms.Queries.GetBloomsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Greenmaster.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloomController(IMediator mediatr) : ControllerBase
{
    [HttpGet("all", Name = "GetAllBlooms")]
    [ProducesResponseType(Status200OK)]
    public async Task<ActionResult<List<BloomListDto>>> Index()
    {
        var blooms = await mediatr.Send(new GetBloomsQuery());
        return Ok(blooms);
    }

    [HttpPost(Name = "CreateBloom")]
    public async Task<ActionResult<BloomDetailDto>> Create([FromBody] CreateBloomCommand createBloomCommand)
    {
        var response = await mediatr.Send(createBloomCommand);
        return Ok(response);
    }
}