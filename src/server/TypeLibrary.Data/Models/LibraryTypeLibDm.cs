﻿using System;
using System.Collections.Generic;
using Mimirorg.Common.Extensions;
using Mimirorg.TypeLibrary.Enums;

namespace TypeLibrary.Data.Models
{
    public class LibraryTypeLibDm
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public LibraryTypeLibDm Parent { get; set; }
        public string Name { get; set; }
        public string Iri { get; set; }
        public string Version { get; set; }
        public string FirstVersionId { get; set; }
        public Aspect Aspect { get; set; }
        public string Description { get; set; }

        public string RdsId { get; set; }
        public RdsLibDm Rds { get; set; }
        public string PurposeId { get; set; }
        public PurposeLibDm Purpose { get; set; }

        public ICollection<LibraryTypeLibDm> Children { get; set; }
        public ICollection<CollectionLibDm> Collections { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public void IncrementMinorVersion()
        {
            Version = Version.IncrementMinorVersion();
        }

        public void IncrementMajorVersion()
        {
            Version = Version.IncrementMajorVersion();
        }
    }
}