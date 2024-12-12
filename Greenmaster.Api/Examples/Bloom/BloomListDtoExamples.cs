using Greenmaster.Application.Features.Blooms.Dto;
using JetBrains.Annotations;
using Swashbuckle.AspNetCore.Filters;
using static Greenmaster.Domain.Shared.Month;

namespace Greenmaster.Api.Examples.Bloom;

[UsedImplicitly]
public class BloomListDtoExamples : IExamplesProvider<IEnumerable<BloomListDto>>
{
    public IEnumerable<BloomListDto> GetExamples()
    {
        yield return new BloomListDto
        {
            Id = Guid.Parse("507f191e-4760-4fc6-a567-e005a32d28d4"),
            IsFragrant = true,
            Period = [April.ToString(), May.ToString()]
        };
    }
}