using MediatR;

namespace Greenmaster.Application.Features.Plants.Commands.CreatePlantCommand;

public class CreatePlantCommand : IRequest<CreatePlantCommandResponse>
{
    public string Genus { get; set; }
    public string Species { get; set; }
    public string CommonName { get; set; } = "Not provided";
    public string? Cultivar { get; set; }
    public Guid BloomId { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}