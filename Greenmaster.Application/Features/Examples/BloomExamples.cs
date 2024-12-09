using Greenmaster.Domain.Entities;
using static Greenmaster.Domain.Shared.Month;
using static Greenmaster.Domain.Shared.Size;

namespace Greenmaster.Application.Features.Examples;

public static class BloomExamples
{
    public static List<Bloom> GetExamples()
    {
        return [
            new Bloom
            {
                Id = Guid.Parse("85633e4c-5bf2-4d3b-9485-d3c77d298279"),
                Period = [April, May, June, July, August, September],
                IsFragrant = true,
                IsEdible = true,
                AttractsPollinators = true,
                Size = Medium
            },
            new Bloom
            {
                Id = Guid.Parse("ccfa831e-4c8b-471e-95ef-aafa632f9651"),
                Period = [May, June, July, August, September],
                IsFragrant = true,
                IsEdible = true,
                AttractsPollinators = true,
                Size = Large
            },
            new Bloom
            {
                Id = Guid.Parse("dc72155a-ee83-445b-bd29-4f13060f74b7"),
                Period = [August, September],
                IsFragrant = false,
                IsEdible = true,
                AttractsPollinators = false,
                Size = Small
            }
        ];
    }
}