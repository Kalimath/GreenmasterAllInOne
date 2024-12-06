using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Exceptions;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.UpdateBloomCommand;

public class UpdateBloomCommandHandler(IMapper mapper, IAsyncRepository<Bloom?> bloomRepository)
    :IRequestHandler<UpdateBloomCommand>
{
    public async Task Handle(UpdateBloomCommand request, CancellationToken cancellationToken)
    {
        var existingBloom = await bloomRepository.GetByIdAsync(request.Id);
        
        var validator = new UpdateBloomCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);
        
        mapper.Map(request, existingBloom, typeof(UpdateBloomCommand), typeof(Bloom));
        
        await bloomRepository.UpdateAsync(existingBloom);
    }
}