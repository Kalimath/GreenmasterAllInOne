using Greenmaster.Application.Features.Blooms.Dto;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;

public class GetBloomDetailQuery : IRequest<BloomDetailDto>
{
    public Guid Id { get; set; }
}