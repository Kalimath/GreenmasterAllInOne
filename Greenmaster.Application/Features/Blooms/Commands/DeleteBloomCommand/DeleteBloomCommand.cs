using MediatR;

namespace Greenmaster.Application.Features.Blooms.Commands.DeleteBloomCommand;

public class DeleteBloomCommand : IRequest
{
    public Guid Id { get; set; }
}