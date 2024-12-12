using Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;
using Greenmaster.Application.Tests.Base;
using Greenmaster.Domain.Entities;
using Greenmaster.Domain.Shared;
using NSubstitute;

namespace Greenmaster.Application.Tests.Blooms.Queries;

public class CreateBloomCommandHandlerTests : BloomTestBase, ICreateCommandHandlerTests
{
    private readonly CreateBloomCommandHandler _handler;

    public CreateBloomCommandHandlerTests()
    {
        _handler = new CreateBloomCommandHandler(Mapper, BloomRepository);
    }

    [Fact]
    public async Task Handle_ReturnsSuccessful_WhenModelIsValid()
    {
        var command = new CreateBloomCommand
        {
            IsEdible = true,
            IsFragrant = false,
            AttractsPollinators = true,
            Size = Size.Large,
            Period = [Month.April , Month.May]
        };
        
        var response = await _handler.Handle(command, CancellationToken.None);
        
        Assert.True(response.Success);
    }

    [Fact]
    public async Task Handle_AddsBloomToRepository_WhenModelIsValid()
    {
        var command = new CreateBloomCommand
        {
            IsEdible = true,
            IsFragrant = false,
            AttractsPollinators = true,
            Size = Size.Large,
            Period = [Month.April , Month.May]
        };
        
        _ = await _handler.Handle(command, CancellationToken.None);
        
        await BloomRepository
            .Received(1)
            .AddAsync(Arg.Is<Bloom>(b => 
                b.Period.SequenceEqual(command.Period) &&
                b.Size == command.Size &&
                b.IsEdible == command.IsEdible &&
                b.IsFragrant == command.IsFragrant &&
                b.AttractsPollinators == command.AttractsPollinators));
    }

    [Fact]
    public async Task Handle_ReturnsCreatedObject_WhenModelIsValid()
    {
        var command = new CreateBloomCommand
        {
            IsEdible = true,
            IsFragrant = false,
            AttractsPollinators = true,
            Size = Size.Large,
            Period = [Month.April , Month.May]
        };
        BloomRepository.AddAsync(Arg.Any<Bloom>()).Returns(new Bloom()
        {
            Id = Guid.NewGuid(),
            IsEdible = command.IsEdible,
            IsFragrant = command.IsFragrant,
            AttractsPollinators = command.AttractsPollinators,
            Size = command.Size,
            Period = command.Period
        });
        
        var response = await _handler.Handle(command, CancellationToken.None);

        var responseData = response.Data;
        Assert.NotNull(responseData);
        Assert.Equal(responseData.IsEdible, command.IsEdible);
        Assert.Equal(responseData.IsFragrant, command.IsFragrant);
        Assert.Equal(responseData.AttractsPollinators, command.AttractsPollinators);
        Assert.Equal(responseData.Size, command.Size.ToString());
        Assert.Equal(responseData.Period, command.Period.Select(month => month.ToString()));
    }

    [Fact]
    public Task Handle_ReturnsUnsuccessful_WithValidationMessage_WhenGenusAndSpeciesNotUnique()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public Task Handle_ReturnsUnsuccessful_WithValidationMessage_WhenPeriodEmpty()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public Task Handle_ReturnsUnsuccessful_WithValidationMessage_WhenPeriodNull()
    {
        throw new NotImplementedException();
    }
}

public interface ICreateCommandHandlerTests : ITestStrategy
{
    Task Handle_ReturnsSuccessful_WhenModelIsValid();
    Task Handle_AddsBloomToRepository_WhenModelIsValid();
    
    Task Handle_ReturnsCreatedObject_WhenModelIsValid();
}