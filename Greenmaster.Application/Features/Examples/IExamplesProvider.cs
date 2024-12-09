namespace Greenmaster.Application.Features.Examples;

public interface IExamplesProvider<T> where T : class
{
    List<T> GetExamples();
}