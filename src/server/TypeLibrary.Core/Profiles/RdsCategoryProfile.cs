﻿using AutoMapper;
using TypeLibrary.Models.Application;
using TypeLibrary.Models.Data;

namespace TypeLibrary.Core.Profiles
{
    public class RdsCategoryProfile : Profile
    {
        public RdsCategoryProfile()
        {
            CreateMap<RdsCategoryAm, RdsCategory>()
                .ForMember(dest => dest.Id, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri));

            CreateMap<RdsCategory, RdsCategoryAm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri));
        }
    }
}