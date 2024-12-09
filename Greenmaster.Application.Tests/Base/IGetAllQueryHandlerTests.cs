namespace Greenmaster.Application.Tests.Base;

public interface IGetAllQueryHandlerTests : ITestStrategy
{
    Task Handle_ReturnsExpectedData();
    Task Handle_ReturnsEmptyList_WhenNoDataFound();
}