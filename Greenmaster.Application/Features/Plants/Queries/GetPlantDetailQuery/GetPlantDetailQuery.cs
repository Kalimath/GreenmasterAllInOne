using Greenmaster.Application.Features.Plants.Dto;
using MediatR;

namespace Greenmaster.Application.Features.Plants.Queries.GetPlantDetailQuery;

public class GetPlantDetailQuery : IRequest<PlantDetailDto>
{
    public Guid Id { get; set; }
}