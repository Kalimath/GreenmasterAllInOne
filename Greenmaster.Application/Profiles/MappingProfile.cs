using AutoMapper;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Features.Plants.Dto;
using Greenmaster.Application.Features.SymbioticRelations.Dto;
using Greenmaster.Domain.Entities;

namespace Greenmaster.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Plant, PlantListDto>().ReverseMap();
        CreateMap<Plant, PlantDetailDto>().ReverseMap();
        CreateMap<Bloom, BloomDto>().ReverseMap();
        CreateMap<Bloom, BloomDetailDto>().ReverseMap();
        CreateMap<SymbioticRelation, SymbioticRelationListDto>().ReverseMap();
    }
}