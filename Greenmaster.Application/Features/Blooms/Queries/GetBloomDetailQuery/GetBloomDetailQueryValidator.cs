using FluentValidation;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;

public class GetBloomDetailQueryValidator : AbstractValidator<GetBloomDetailQuery>
{
    public GetBloomDetailQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}