using FluentValidation;

namespace Greenmaster.Application.Features.Blooms.Commands.UpdateBloomCommand;

public class UpdateBloomCommandValidator : AbstractValidator<UpdateBloomCommand>
{
    public UpdateBloomCommandValidator()
    {
        RuleFor(x => x.Period).ForEach(p => p.IsInEnum());
        RuleFor(x => x.Size).IsInEnum();
    }
}