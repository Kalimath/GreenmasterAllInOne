namespace Greenmaster.Application.Features.Blooms.Dto;

public class BloomDto
{
    public Guid Id { get; set; }
    public string Period { get; set; }
    public bool IsFragrant { get; set; } = false;
}