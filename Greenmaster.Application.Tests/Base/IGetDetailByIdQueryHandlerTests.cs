namespace Greenmaster.Application.Tests.Base;

public interface IGetDetailByIdQueryHandlerTests : ITestStrategy
{
    Task Handle_ReturnsExpectedData_WhenIdExists();
    Task Handle_ReturnsUnsuccessful_WhenIdDoesNotExist();
    Task Handle_ReturnsDataNull_WhenIdDoesNotExist();
    Task Handle_ReturnsExpectedValidationMessage_WhenIdDoesNotExist();
}