namespace Greenmaster.Application.Features.Plants.Dto;

public class PlantListDto
{
    public Guid Id { get; set; }
    
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    
    public string ImageUrl { get; set; }
}