using Greenmaster.Application.Features.Blooms.Dto;

namespace Greenmaster.Application.Features.Plants.Dto;

public class PlantDetailDto
{
    public Guid Id { get; set; }
    
    public string Genus  { get; set; }
    public string Species { get; set; }
    public string Cultivar { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }

    public Guid BloomId { get; set; }
    public BloomListDto BloomList { get; set; } = default!;
    
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}