using Greenmaster.Domain.Shared;

namespace Greenmaster.Domain.Entities;

public class Bloom
{
    public Guid Id { get; set; }
    public string Period { get; set; } //TODO: Use enum for period
    public bool IsFragrant { get; set; } = false;
    public bool IsEdible { get; set; } = false;
    public bool AttractsPollinators { get; set; } = false;
    public Size Size { get; set; } = Size.Medium;
}