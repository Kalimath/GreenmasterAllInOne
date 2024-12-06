using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Exceptions;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;

public class CreateBloomCommandHandler(IMapper mapper, IAsyncRepository<Bloom> bloomRepository)
    :IRequestHandler<CreateBloomCommand, Guid>
{
    public async Task<Guid> Handle(CreateBloomCommand request, CancellationToken cancellationToken)
    {
        var bloom = mapper.Map<Bloom>(request);
        
        var validator = new CreateBloomCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);
        
        bloom = await bloomRepository.AddAsync(bloom);
        
        return bloom.Id;
    }
}