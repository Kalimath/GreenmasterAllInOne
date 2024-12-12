using Greenmaster.Domain.Shared;

namespace Greenmaster.Domain.Entities;

public class SymbioticRelation
{
    public Guid Id { get; set; }
    public required Plant SymbiontA { get; set; }
    public required Plant SymbiontB { get; set; }
    public SymbiosisType Type { get; set; }
}