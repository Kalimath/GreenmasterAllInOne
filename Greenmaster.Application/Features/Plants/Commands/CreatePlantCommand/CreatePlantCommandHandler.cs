using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Plants.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Plants.Commands.CreatePlantCommand;

public class CreatePlantCommandHandler(
    IMapper mapper, 
    IAsyncRepository<Plant> plantRepository,
    IAsyncRepository<Bloom> bloomRepository) 
    : IRequestHandler<CreatePlantCommand, CreatePlantCommandResponse>
{
    public async Task<CreatePlantCommandResponse> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
    {
        var response = new CreatePlantCommandResponse();
        
        var validator = new CreatePlantCommandValidator((IPlantRepository)plantRepository, (IBloomRepository)bloomRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        
        if (response.Success){
            var plant = mapper.Map<Plant>(request);
            var savedPlant = await plantRepository.AddAsync(plant);
            response.Data = mapper.Map<PlantDetailDto>(savedPlant);
        }
        
        return response;
    }
}