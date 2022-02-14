﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mimirorg.Common.Extensions;
using Mimirorg.TypeLibrary.Enums;
using Mimirorg.TypeLibrary.Extensions;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Core.Profiles
{
    public class LibraryTypeProfile : Profile
    {
        public LibraryTypeProfile()
        {
            CreateMap<LibraryTypeLibAm, NodeLibDm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Key}-{src.Domain}-{src.Version}".CreateMd5()))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.AttributeAspectId, opt => opt.MapFrom(src => src.AttributeAspectId))
                .ForMember(dest => dest.BlobId, opt => opt.MapFrom(src => src.BlobId))
                .ForMember(dest => dest.TerminalNodes, opt => opt.MapFrom(src => CreateTerminals(src.Terminals.ToList(), $"{src.Key}-{src.Domain}".CreateMd5()).ToList()))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => CreateAttributes(src.AttributeIdList.ToList()).ToList()))
                .ForMember(dest => dest.Simple, opt => opt.MapFrom(src => SimpleTypes(src.Simple.ToList()).ToList()))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .ForMember(dest => dest.Purpose, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .AfterMap((_, dest, _) =>
                {
                    dest.ResolveAttributePredefined();
                });

            CreateMap<LibraryTypeLibAm, TransportLibDm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Key}-{src.Domain}-{src.Version}".CreateMd5()))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .ForMember(dest => dest.Purpose, opt => opt.Ignore())
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => CreateAttributes(src.AttributeIdList.ToList()).ToList()))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<LibraryTypeLibAm, InterfaceLibDm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Key}-{src.Domain}-{src.Version}".CreateMd5()))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => CreateAttributes(src.AttributeIdList.ToList()).ToList()))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .ForMember(dest => dest.Purpose, opt => opt.Ignore())
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<NodeLibDm, LibraryTypeLibAm>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => ObjectType.ObjectBlock))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Terminals, opt => opt.MapFrom(src => src.TerminalNodes))
                .ForMember(dest => dest.AttributeIdList, opt => opt.MapFrom(src => src.Attributes.Select(x => x.Id)))
                .ForMember(dest => dest.Simple, opt => opt.MapFrom(src => src.Simple.Select(x => x.Id)))
                .ForMember(dest => dest.AttributeAspectId, opt => opt.MapFrom(src => src.AttributeAspectId))
                .ForMember(dest => dest.BlobId, opt => opt.MapFrom(src => src.BlobId))
                .ForMember(dest => dest.AttributesPredefined, opt => opt.MapFrom(src => src.AttributesPredefined))
                .ForMember(dest => dest.TerminalId, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .BeforeMap((src, _, _) =>
                {
                    src.ResolveAttributesPredefined();
                });

            CreateMap<TransportLibDm, LibraryTypeLibAm>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => ObjectType.Transport))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Terminals, opt => opt.Ignore())
                .ForMember(dest => dest.AttributeIdList, opt => opt.MapFrom(src => src.Attributes.Select(x => x.Id)))
                .ForMember(dest => dest.Simple, opt => opt.Ignore())
                .ForMember(dest => dest.AttributeAspectId, opt => opt.Ignore())
                .ForMember(dest => dest.BlobId, opt => opt.Ignore())
                .ForMember(dest => dest.AttributesPredefined, opt => opt.Ignore())
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<InterfaceLibDm, LibraryTypeLibAm>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FirstVersionId, opt => opt.MapFrom(src => src.FirstVersionId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => ObjectType.Interface))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Collections, opt => opt.MapFrom(src => src.Collections))
                .ForMember(dest => dest.RdsId, opt => opt.MapFrom(src => src.RdsId))
                .ForMember(dest => dest.Terminals, opt => opt.Ignore())
                .ForMember(dest => dest.AttributeIdList, opt => opt.MapFrom(src => src.Attributes.Select(x => x.Id)))
                .ForMember(dest => dest.Simple, opt => opt.Ignore())
                .ForMember(dest => dest.AttributeAspectId, opt => opt.Ignore())
                .ForMember(dest => dest.BlobId, opt => opt.Ignore())
                .ForMember(dest => dest.AttributesPredefined, opt => opt.Ignore())
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.PurposeId, opt => opt.MapFrom(src => src.PurposeId))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<TerminalNodeLibDm, TerminalItemLibDm>()
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.ConnectorDirection, opt => opt.MapFrom(src => src.ConnectorDirection));

            CreateMap<NodeLibDm, NodeLibCm>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Rds, opt => opt.MapFrom(src => src.Rds.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Rds.RdsCategory.Name))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes))
                .ForMember(dest => dest.BlobId, opt => opt.MapFrom(src => src.BlobId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<TransportLibDm, TransportLibCm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Rds, opt => opt.MapFrom(src => src.Rds.Code))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Rds.RdsCategory.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
            
            CreateMap<InterfaceLibDm, InterfaceLibCm>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Rds, opt => opt.MapFrom(src => src.Rds.Code))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Rds.RdsCategory.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Aspect, opt => opt.MapFrom(src => src.Aspect))
                .ForMember(dest => dest.Iri, opt => opt.MapFrom(src => src.Iri))
                .ForMember(dest => dest.TerminalId, opt => opt.MapFrom(src => src.TerminalId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
        }

        private static IEnumerable<TerminalNodeLibDm> CreateTerminals(IReadOnlyCollection<TerminalItemLibAm> terminals, string nodeId)
        {
            if (terminals == null || !terminals.Any())
                yield break;

            var sortedTerminalTypes = new List<TerminalItemLibAm>();

            foreach (var item in terminals)
            {
                var existingSortedTerminalType = sortedTerminalTypes.FirstOrDefault(x => x.TerminalId == item.TerminalId && x.ConnectorDirection == item.ConnectorDirection);
                if (existingSortedTerminalType == null)
                {
                    sortedTerminalTypes.Add(item);
                }
                else
                {
                    existingSortedTerminalType.Number += item.Number;
                }
            }

            foreach (var item in sortedTerminalTypes)
            {
                var key = $"{item.Key}-{nodeId}"; 
                yield return new TerminalNodeLibDm
                {
                    Id = key.CreateMd5(),
                    NodeId = nodeId,
                    TerminalId = item.TerminalId,
                    Number = item.Number,
                    ConnectorDirection = item.ConnectorDirection
                };
            }
        }

        private static IEnumerable<AttributeLibDm> CreateAttributes(IReadOnlyCollection<string> attributes)
        {
            if (attributes == null || !attributes.Any())
                yield break;

            foreach (var item in attributes)
                yield return new AttributeLibDm
                {
                    Id = item
                };
        }

        private static IEnumerable<SimpleLibDm> SimpleTypes(IReadOnlyCollection<string> simpleTypes)
        {
            if (simpleTypes == null || !simpleTypes.Any())
                yield break;
            foreach (var item in simpleTypes)
                yield return new SimpleLibDm
                {
                    Id = item
                };
        }
    }
}