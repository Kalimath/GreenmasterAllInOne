using Greenmaster.Application.Features.SymbioticRelations.Dto;
using MediatR;

namespace Greenmaster.Application.Features.SymbioticRelations.Queries.GetSymbioticRelationsQuery;

public class GetSymbioticRelationsQuery : IRequest<SymbioticRelationListDto>, IRequest<List<SymbioticRelationListDto>>
{
    
}