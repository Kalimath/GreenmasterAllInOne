using FluentValidation;
using Greenmaster.Application.Contracts.Persistence;

namespace Greenmaster.Application.Features.Plants.Commands.CreatePlantCommand;

public class CreatePlantCommandValidator : AbstractValidator<CreatePlantCommand>
{
    private readonly IPlantRepository _plantRepository;
    private readonly IBloomRepository _bloomRepository;

    public CreatePlantCommandValidator(IPlantRepository plantRepository, IBloomRepository bloomRepository)
    {
        _plantRepository = plantRepository;
        _bloomRepository = bloomRepository;
        RuleFor(p => p.Genus)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        
        RuleFor(p => p.Species)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        
        RuleFor(p => p.CommonName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        
        RuleFor(p => p.Description)
            .NotNull()
            .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters");

        RuleFor(p => p.Cultivar)
            .Must(s => s is not null)
            .NotEmpty().WithMessage("{PropertyName} is required");
        
        RuleFor(p => p)
           .MustAsync(GenusAndSpeciesUnique)
           .WithMessage("A plant with the same genus and species already exists");
        
        RuleFor(p => p)
            .MustAsync(BloomExists)
            .WithMessage("The specified bloom does not exist");
    }

    private async Task<bool> GenusAndSpeciesUnique(CreatePlantCommand p, CancellationToken cancellationToken)
    {
        return !(await _plantRepository.PlantGenusAndSpeciesUnique(p.Genus, p.Species));
    }

    private async Task<bool> BloomExists(CreatePlantCommand p, CancellationToken cancellationToken)
    {
        return await _bloomRepository.GetByIdAsync(p.BloomId) is not null;
    }
}