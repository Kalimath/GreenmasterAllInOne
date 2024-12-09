using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Domain.Entities;

namespace Greenmaster.Persistence.Repositories;

public class SymbioticRelationRepository(BotanicalDbContext context) : BaseRepository<SymbioticRelation>(context), ISymbioticRelationRepository
{
}