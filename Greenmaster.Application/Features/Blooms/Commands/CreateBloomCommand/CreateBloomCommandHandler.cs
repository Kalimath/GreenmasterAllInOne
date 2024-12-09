using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Exceptions;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;

public class CreateBloomCommandHandler(IMapper mapper, IAsyncRepository<Bloom> bloomRepository)
    :IRequestHandler<CreateBloomCommand, CreateBloomCommandResponse>
{
    public async Task<CreateBloomCommandResponse> Handle(CreateBloomCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateBloomCommandResponse();
        
        var validator = new CreateBloomCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
            
        if (response.Success)
        {
            var bloom = mapper.Map<Bloom>(request);
            var savedBloom = await bloomRepository.AddAsync(bloom);
            response.Data = mapper.Map<BloomDetailDto>(savedBloom);
        }
        
        return response;
    }
}