using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Shared;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;

public class GetBloomDetailQuery : IRequest<ObjectResponse<BloomDetailDto>>
{
    public Guid Id { get; set; }
}