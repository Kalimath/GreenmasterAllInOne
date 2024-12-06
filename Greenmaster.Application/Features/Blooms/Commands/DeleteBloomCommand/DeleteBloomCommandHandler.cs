using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.DeleteBloomCommand;

public class DeleteBloomCommandHandler(IAsyncRepository<Bloom?> bloomRepository)
    : IRequestHandler<DeleteBloomCommand>
{
    public async Task Handle(DeleteBloomCommand request, CancellationToken cancellationToken)
    {
        var bloomToDelete = await bloomRepository.GetByIdAsync(request.Id);
        
        //TODO: validation
        
        await bloomRepository.DeleteAsync(bloomToDelete);
    }
}