namespace Greenmaster.Application.Features.Blooms.Dto;

public class BloomDetailDto
{
    public Guid Id { get; set; }
    public string Period { get; set; }
    public bool IsFragrant { get; set; } = false;
    public bool IsEdible { get; set; } = false;
    public bool AttractsPollinators { get; set; } = false;
    public string Size { get; set; } = Domain.Shared.Size.Medium.ToString();
}