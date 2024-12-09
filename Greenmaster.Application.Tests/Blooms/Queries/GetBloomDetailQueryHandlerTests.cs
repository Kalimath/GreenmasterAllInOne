using Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;
using Greenmaster.Application.Tests.Base;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Greenmaster.Application.Tests.Blooms.Queries;

public class GetBloomDetailQueryHandlerTests : BloomTestBase, IGetDetailByIdQueryHandlerTests
{
    private readonly GetBloomDetailQueryHandler _handler;

    public GetBloomDetailQueryHandlerTests()
    {
        _handler = new GetBloomDetailQueryHandler(Mapper, BloomRepository);
    }

    [Fact]
    public async Task Handle_ReturnsExpectedData_WhenIdExists()
    {
        BloomRepository.GetByIdAsync(SomeBloom.Id).Returns(SomeBloom);

        var result = await _handler.Handle(new GetBloomDetailQuery{Id = SomeBloom.Id}, CancellationToken.None);

        Assert.NotNull(result.Data);
        Assert.Equal(SomeBloom.Id, result.Data.Id);
    }

    [Fact]
    public async Task Handle_ReturnsUnsuccessful_WhenIdDoesNotExist()
    {
        BloomRepository.GetByIdAsync(default).ReturnsNullForAnyArgs();
        
        var result = await _handler.Handle(new GetBloomDetailQuery{Id = SomeBloom.Id}, CancellationToken.None);
        
        Assert.False(result.Success);
    }

    [Fact]
    public async Task Handle_ReturnsDataNull_WhenIdDoesNotExist()
    {
        BloomRepository.GetByIdAsync(default).ReturnsNullForAnyArgs();
        
        var result = await _handler.Handle(new GetBloomDetailQuery{Id = SomeBloom.Id}, CancellationToken.None);
        
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task Handle_ReturnsExpectedValidationMessage_WhenIdDoesNotExist()
    {
        BloomRepository.GetByIdAsync(default).ReturnsNullForAnyArgs();
        
        var result = await _handler.Handle(new GetBloomDetailQuery{Id = default}, CancellationToken.None);

        Assert.NotNull(result.ValidationErrors);
        Assert.Contains(result.ValidationErrors, s => s.Equals("Id is required"));
    }
}