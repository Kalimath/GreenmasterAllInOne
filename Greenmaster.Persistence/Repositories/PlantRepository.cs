using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Domain.Entities;

namespace Greenmaster.Persistence.Repositories;

public class PlantRepository(BotanicalDbContext context) : BaseRepository<Plant>(context), IPlantRepository
{
    public Task<bool> PlantGenusAndSpeciesUnique(string genus, string species)
    {
        var combinationExists = context.Plants.Any(p => p.Genus == genus && p.Species == species);
        return Task.FromResult(combinationExists);
    }
}