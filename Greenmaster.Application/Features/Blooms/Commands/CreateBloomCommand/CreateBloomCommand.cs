using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Shared;
using Greenmaster.Domain.Shared;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;

public class CreateBloomCommand : IRequest<ObjectResponse<BloomDetailDto>>
{
    public required Month[] Period { get; set; }
    public bool IsFragrant { get; set; }
    public bool IsEdible { get; set; }
    public bool AttractsPollinators { get; set; }
    public Size Size { get; set; } = Size.Medium;

    public override string ToString() => 
        $"Bloom period: {string.Join(", ", Period)}, " +
        $"IsFragrant: {IsFragrant}, " +
        $"IsEdible: {IsEdible}, " +
        $"AttractsPollinators: {AttractsPollinators}, " +
        $"Size: {Size}";
}