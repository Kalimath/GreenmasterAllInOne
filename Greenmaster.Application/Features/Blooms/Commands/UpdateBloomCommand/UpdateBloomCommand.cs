using Greenmaster.Domain.Shared;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.UpdateBloomCommand;

public class UpdateBloomCommand : IRequest
{
    public required Guid Id { get; set; }
    public required Month[] Period { get; set; }
    public bool IsFragrant { get; set; } = false;
    public bool IsEdible { get; set; } = false;
    public bool AttractsPollinators { get; set; } = false;
    public Size Size { get; set; } = Size.Medium;

    public override string ToString() => 
        $"Bloom period: {string.Join(", ", Period)}, " +
        $"IsFragrant: {IsFragrant}, " +
        $"IsEdible: {IsEdible}, " +
        $"AttractsPollinators: {AttractsPollinators}, " +
        $"Size: {Size}";
}