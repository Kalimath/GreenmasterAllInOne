using Greenmaster.Application.Contracts.API;
using Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;
using Greenmaster.Application.Features.Blooms.Commands.DeleteBloomCommand;
using Greenmaster.Application.Features.Blooms.Commands.UpdateBloomCommand;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;
using Greenmaster.Application.Features.Blooms.Queries.GetBloomsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Greenmaster.Api.Controllers;

[ApiController]
[Route(BloomApi.Route)]
[Consumes("application/json")]
public class BloomController(IMediator mediatr) : ControllerBase
{
    [HttpGet("all", Name = "GetAllBlooms")]
    [SwaggerResponseExample(Status200OK, typeof(IEnumerable<BloomListDto>))]
    public async Task<ActionResult<List<BloomListDto>>> Index()
    {
        var blooms = await mediatr.Send(new GetBloomsQuery());
        return Ok(blooms);
    }

    [HttpPost(Name = "CreateBloom")]
    [ProducesResponseType(Status202Accepted)] 
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<BloomDetailDto>> Create([FromBody] CreateBloomCommand createBloomCommand)
    {
        var response = await mediatr.Send(createBloomCommand);
        return Accepted(response);
    }

    [HttpGet("{id:guid}", Name = "GetBloomById")]
    [ProducesResponseType(Status200OK)] 
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<BloomDetailDto>> GetById(Guid id)
    {
        var getBloomDetailQuery = new GetBloomDetailQuery{Id = id};
        return Ok(await mediatr.Send(getBloomDetailQuery));
    }

    [HttpPut(Name = "UpdateBloom")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateBloomCommand updateBloomCommand)
    {
        await mediatr.Send(updateBloomCommand); //TODO: may not be fully implemented
        return NoContent();
    }

    [HttpDelete("{id:guid}", Name = "DeleteBloom")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteBloomCommand = new DeleteBloomCommand{Id = id};
        await mediatr.Send(deleteBloomCommand); //TODO: may not be fully implemented
        return NoContent();
    }
}