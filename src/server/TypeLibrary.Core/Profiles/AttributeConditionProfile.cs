﻿using System;
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
    public class AttributeConditionProfile : Profile
    {
        public AttributeConditionProfile(IApplicationSettingsRepository settings, IHttpContextAccessor contextAccessor)
        {
            CreateMap<AttributeConditionLibAm, AttributeConditionLibDm>()
                .ForMember(dest => dest.Id, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ContentReferences, opt => opt.MapFrom(src => src.ContentReferences.ConvertToUriString()))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => $"{settings.ApplicationSemanticUrl}/attribute/condition/{HttpUtility.UrlEncode(src.Name)}"))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(contextAccessor.GetName()) ? "Unknown" : contextAccessor.GetName()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));

            CreateMap<AttributeConditionLibDm, AttributeConditionLibCm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.ContentReferences, opt => opt.MapFrom(src => src.ContentReferences.ConvertToArray()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}