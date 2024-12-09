using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Shared;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.Blooms.Queries.GetBloomDetailQuery;

public class GetBloomDetailQueryHandler(IMapper mapper, IAsyncRepository<Bloom> bloomRepository)
    : IRequestHandler<GetBloomDetailQuery, ObjectResponse<BloomDetailDto>> 
{
    public async Task<ObjectResponse<BloomDetailDto>> Handle(GetBloomDetailQuery request, CancellationToken cancellationToken)
    {
        var response = new ObjectResponse<BloomDetailDto>();
        
        var validator = new GetBloomDetailQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }

        if (response.Success)
        {
            var bloom = await bloomRepository.GetByIdAsync(request.Id);
            
            if (bloom == null) return new ObjectResponse<BloomDetailDto>(){ Success = false};
            response.Data = mapper.Map<BloomDetailDto>(bloom);
        }

        return response;
    }
}