using Greenmaster.Application.Features.Plants.Dto;
using MediatR;

namespace Greenmaster.Application.Features.Plants.Queries.GetPlantsQuery;

public class GetPlantsQuery : IRequest<List<PlantListDto>>
{
    
}