using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomsQuery;

public class GetBloomsQueryHandler(IMapper mapper, IAsyncRepository<Bloom> bloomRepository)
    : IRequestHandler<GetBloomsQuery, List<BloomListDto>>
{
    public async Task<List<BloomListDto>> Handle(GetBloomsQuery request, CancellationToken cancellationToken)
    {
        var blooms = (await bloomRepository.GetAllAsync());
        
        return mapper.Map<List<BloomListDto>>(blooms);
    }
}