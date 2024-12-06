using FluentValidation;

namespace Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;

public class CreateBloomCommandValidator : AbstractValidator<CreateBloomCommand>
{
    public CreateBloomCommandValidator()
    {
        RuleFor(x => x.Period).ForEach(p => p.IsInEnum());
        RuleFor(x => x.Size).IsInEnum();
    }
}