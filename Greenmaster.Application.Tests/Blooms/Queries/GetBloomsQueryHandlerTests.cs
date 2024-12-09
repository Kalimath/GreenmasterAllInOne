using Greenmaster.Application.Features.Blooms.Queries.GetBloomsQuery;
using Greenmaster.Application.Tests.Base;
using NSubstitute;

namespace Greenmaster.Application.Tests.Blooms.Queries;

public class GetBloomsQueryHandlerTests : BloomTestBase, IGetAllQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsExpectedData()
    {
        BloomRepository.GetAllAsync().Returns(SomeBlooms);
        var handler = new GetBloomsQueryHandler(Mapper, BloomRepository);
        
        var result = await handler.Handle(new GetBloomsQuery(), CancellationToken.None);

        Assert.NotEmpty(result);
        Assert.Equal(SomeBlooms.Count, result.Count);
        Assert.Equivalent(SomeBlooms.Select(b => b.Id), result.Select(b => b.Id));
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoDataFound()
    {
        BloomRepository.GetAllAsync().Returns([]);
        var handler = new GetBloomsQueryHandler(Mapper, BloomRepository);
        
        var result = await handler.Handle(new GetBloomsQuery(), CancellationToken.None);

        Assert.Empty(result);
    }
}