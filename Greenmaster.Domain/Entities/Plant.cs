using Greenmaster.Domain.Common;

namespace Greenmaster.Domain.Entities;

public class Plant : ISymbiotable
{
    public Guid Id { get; set; }
    
    public string Genus { get; set; }
    public string Species { get; set; }
    public string CommonName { get; set; } = "Not provided";
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrWhiteSpace(Cultivar) ? "" : $" '{Cultivar}'");
    
    public Guid BloomId { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}