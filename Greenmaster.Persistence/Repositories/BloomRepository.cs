using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Domain.Entities;

namespace Greenmaster.Persistence.Repositories;

public class BloomRepository(BotanicalDbContext context) : BaseRepository<Bloom>(context), IBloomRepository
{
}