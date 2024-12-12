using AutoMapper;
using Greenmaster.Application.Features.Blooms.Commands.CreateBloomCommand;
using Greenmaster.Application.Features.Blooms.Dto;
using Greenmaster.Application.Features.Plants.Dto;
using Greenmaster.Application.Features.SymbioticRelations.Dto;
using Greenmaster.Domain.Entities;
using Greenmaster.Domain.Shared;

namespace Greenmaster.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Plant
        CreateMap<Plant, PlantListDto>().ReverseMap();
        CreateMap<Plant, PlantDetailDto>().ReverseMap();
        
        //Bloom
        CreateMap<Bloom, BloomListDto>().ForMember(
            dest => dest.Period,
            opt => opt.MapFrom(src => src.Period)).ReverseMap();
        CreateMap<Bloom, BloomDetailDto>().ReverseMap();
        CreateMap<Bloom, CreateBloomCommand>().ReverseMap();
            
        //SymbioticRelation
        CreateMap<SymbioticRelation, SymbioticRelationListDto>().ReverseMap();
        
        CreateMap<Month[], string[]>().ConvertUsing(months => months.Select(Enum.GetName).ToArray()!);
    }
}

