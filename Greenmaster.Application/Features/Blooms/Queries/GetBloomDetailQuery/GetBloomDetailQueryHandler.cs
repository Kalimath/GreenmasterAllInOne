using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;

public class GetBloomDetailQueryHandler(IMapper mapper, IAsyncRepository<Bloom> bloomRepository)
    : IRequestHandler<GetBloomDetailQuery, BloomDetailDto> 
{
    public async Task<BloomDetailDto> Handle(GetBloomDetailQuery request, CancellationToken cancellationToken)
    {
        var bloom = await bloomRepository.GetByIdAsync(request.Id);
        
        return mapper.Map<BloomDetailDto>(bloom);
    }
}