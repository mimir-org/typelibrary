using System;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Mimirorg.Common.Extensions;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Core.Profiles
{
    public class AttributePredefinedProfile : Profile
    {
        public AttributePredefinedProfile(IApplicationSettingsRepository settings, IHttpContextAccessor contextAccessor)
        {
            CreateMap<AttributePredefinedLibAm, AttributePredefinedLibDm>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key.Trim()))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => $"{settings.ApplicationSemanticUrl}/attribute/predefined/{HttpUtility.UrlEncode(src.Key.Trim())}"))
                .ForMember(dest => dest.ContentReferences, opt => opt.MapFrom(src => src.ContentReferences.ConvertToUriString()))
                .ForMember(dest => dest.ValueStringList, opt => opt.MapFrom(src => src.ValueStringList))
                .ForMember(dest => dest.IsMultiSelect, opt => opt.MapFrom(src => src.IsMultiSelect))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(contextAccessor.GetName()) ? "Unknown" : contextAccessor.GetName()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));

            CreateMap<AttributePredefinedLibDm, AttributePredefinedLibCm>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.ContentReferences, opt => opt.MapFrom(src => src.ContentReferences.ConvertToArray()))
                .ForMember(dest => dest.ValueStringList, opt => opt.MapFrom(src => src.ValueStringList))
                .ForMember(dest => dest.IsMultiSelect, opt => opt.MapFrom(src => src.IsMultiSelect))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}