using Greenmaster.Application.Features.SymbioticRelations.Dto;
using Greenmaster.Domain.Common;
using Greenmaster.Domain.Entities;

namespace Greenmaster.Application.Mappers;

public class SymbiotableMapper
{
    public static SymbiontDto MapToSymbiontDto(ISymbiotable? symbiont)
    {
        return symbiont switch
        {
            Plant plant => new SymbiontDto { Id = plant.Id, Name = plant.ScientificName },
            _ => throw new ArgumentException($"Unsupported symbiont type: {symbiont?.GetType().Name}")
        };
    }
}