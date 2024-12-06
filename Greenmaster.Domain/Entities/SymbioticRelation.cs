using Greenmaster.Domain.Common;
using Greenmaster.Domain.Shared;

namespace Greenmaster.Domain.Entities;

public class SymbioticRelation
{
    public Guid Id { get; set; }
    public required ISymbiotable SymbiontA { get; set; }
    public required ISymbiotable SymbiontB { get; set; }
    public SymbiosisType Type { get; set; }
}