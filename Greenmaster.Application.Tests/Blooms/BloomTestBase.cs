using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Profiles;
using Greenmaster.Domain.Entities;
using NSubstitute;
using static Greenmaster.Domain.Shared.Month;
using static Greenmaster.Domain.Shared.Size;

namespace Greenmaster.Application.Tests.Blooms;

public abstract class BloomTestBase
{
    protected readonly IMapper Mapper;
    protected readonly IAsyncRepository<Bloom> BloomRepository;
    protected readonly Bloom SomeBloom = new()
    {
        Id = Guid.Parse("ccfa831e-4c8b-471e-95ef-aafa632f9651"),
        Period = [May, June, July, August, September],
        IsFragrant = true,
        IsEdible = true,
        AttractsPollinators = true,
        Size = Large
    };

    protected readonly Bloom SomeOtherBloom = new()
    {
        Id = Guid.Parse("dc72155a-ee83-445b-bd29-4f13060f74b7"),
        Period = [August, September],
        IsFragrant = false,
        IsEdible = true,
        AttractsPollinators = false,
        Size = Small
    };

    protected readonly List<Bloom> SomeBlooms;

    protected BloomTestBase()
    {
        BloomRepository = Substitute.For<IAsyncRepository<Bloom>>();
        Mapper = BuildMapper();
        SomeBlooms = [SomeBloom, SomeOtherBloom];
    }

    private static IMapper BuildMapper()
    {
        return new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
    }

    protected static void AssertBloomsAreEqual(Bloom bloom1, Bloom bloom2)
    {
        Assert.Equal(bloom1.Id, bloom2.Id);
        Assert.Equal(bloom1.Period, bloom2.Period);
        Assert.Equal(bloom1.IsFragrant, bloom2.IsFragrant);
        Assert.Equal(bloom1.IsEdible, bloom2.IsEdible);
        Assert.Equal(bloom1.AttractsPollinators, bloom2.AttractsPollinators);
        Assert.Equal(bloom1.Size, bloom2.Size);
    }
}