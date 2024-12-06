using Greenmaster.Domain.Entities;

namespace Greenmaster.Application.Contracts.Persistence;

public interface IPlantRepository : IAsyncRepository<Plant> 
{
    Task<bool> PlantGenusAndSpeciesUnique(string genus, string species);
}