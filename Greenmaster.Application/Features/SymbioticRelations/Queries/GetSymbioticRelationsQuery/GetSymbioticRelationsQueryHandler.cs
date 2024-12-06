using AutoMapper;
using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Application.Features.SymbioticRelations.Dto;
using Greenmaster.Application.Mappers;
using Greenmaster.Domain.Entities;
using MediatR;

namespace Greenmaster.Application.Features.SymbioticRelations.Queries.GetSymbioticRelationsQuery;

public class GetSymbioticRelationsQueryHandler(IMapper mapper, IAsyncRepository<SymbioticRelation> symbiosisRepository, IAsyncRepository<Plant> plantRepository)
    : IRequestHandler<GetSymbioticRelationsQuery, List<SymbioticRelationListDto>>
{
    public async Task<List<SymbioticRelationListDto>> Handle(GetSymbioticRelationsQuery request, CancellationToken cancellationToken)
    {
        var symbioticRelations = await symbiosisRepository.GetAllAsync();
        
        var symbioticRelationListDtos = mapper.Map<List<SymbioticRelationListDto>>(symbioticRelations);
        
        return symbioticRelationListDtos.Select(dto =>
        {
            var symbiontA = SymbiotableMapper.MapToSymbiontDto(symbioticRelations.FirstOrDefault(s => s.Id == dto.Id)?.SymbiontA);
            var symbiontB = SymbiotableMapper.MapToSymbiontDto(symbioticRelations.FirstOrDefault(s => s.Id == dto.Id)?.SymbiontB);
            
            dto.SymbiontA = symbiontA;
            dto.SymbiontB = symbiontB;
            
            return dto;
        }).ToList();
    }
}