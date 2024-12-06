using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Features.Plants.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Plants.Queries.GetPlantDetailQuery;

public class GetPlantDetailQueryHandler(
    IMapper mapper, 
    IAsyncRepository<Plant> plantRepository,
    IAsyncRepository<Bloom> bloomRepository)
    : IRequestHandler<GetPlantDetailQuery, PlantDetailDto>
{
    public async Task<PlantDetailDto> Handle(GetPlantDetailQuery request, CancellationToken cancellationToken)
    {
        var plant = await plantRepository.GetByIdAsync(request.Id);
        var plantDetailDto = mapper.Map<PlantDetailDto>(plant);
        
        var bloom = await bloomRepository.GetByIdAsync(plant.BloomId);
        
        plantDetailDto.Bloom = mapper.Map<BloomDto>(bloom);
        
        return plantDetailDto;
    }
}