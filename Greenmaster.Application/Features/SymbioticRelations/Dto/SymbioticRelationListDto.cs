namespace Greenmaster.Application.Features.SymbioticRelations.Dto;

public class SymbioticRelationListDto
{
    public Guid Id { get; set; }
    public SymbiontDto SymbiontA { get; set; }
    public SymbiontDto SymbiontB { get; set; }
    public string Type { get; set; }
}