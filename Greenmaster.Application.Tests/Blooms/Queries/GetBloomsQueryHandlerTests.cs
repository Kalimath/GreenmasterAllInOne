using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Blooms.Queries.GetBloomsQuery;
using Greenmaster.Application.Features.Examples;
using Greenmaster.Application.Profiles;
using Greenmaster.Domain.Entities;
using NSubstitute;

namespace Greenmaster.Application.Tests.Blooms.Queries;

public class GetBloomsQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Bloom> _bloomRepository;

    public GetBloomsQueryHandlerTests()
    {
        _bloomRepository = Substitute.For<IAsyncRepository<Bloom>>();
        var configProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = configProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ReturnsExpectedBlooms()
    {
        var blooms = BloomExamples.GetExamples();

        _bloomRepository.GetAllAsync().Returns(blooms);

        var handler = new GetBloomsQueryHandler(_mapper, _bloomRepository);
        var result = await handler.Handle(new GetBloomsQuery(), CancellationToken.None);

        Assert.NotEmpty(result);
        Assert.Equal(blooms.Count, result.Count);
        Assert.Equivalent(blooms.Select(b => b.Id), result.Select(b => b.Id));
    }
}