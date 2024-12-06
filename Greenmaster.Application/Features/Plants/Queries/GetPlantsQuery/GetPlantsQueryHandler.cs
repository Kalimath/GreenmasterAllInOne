using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Plants.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Plants.Queries.GetPlantsQuery;

public class GetPlantsQueryHandler(IMapper mapper, IAsyncRepository<Plant> plantRepository)
    : IRequestHandler<GetPlantsQuery, List<PlantListDto>>
{
    public async Task<List<PlantListDto>> Handle(GetPlantsQuery request, CancellationToken cancellationToken)
    {
        var plants = (await plantRepository.GetAllAsync()).OrderBy(p => p.Genus);
        
        return mapper.Map<List<PlantListDto>>(plants);
    }
}