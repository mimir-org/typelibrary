﻿using System;
using System.Collections.Generic;
using Mimirorg.TypeLibrary.Enums;

namespace TypeLibrary.Data.Models
{
    public class TransportLibDm
    {
        public string Id { get; set; }
        public string Iri { get; set; }
        public string Name { get; set; }
        public string RdsId { get; set; }
        public RdsLibDm Rds { get; set; }
        public string PurposeId { get; set; }
        public PurposeLibDm Purpose { get; set; }
        public string ParentId { get; set; }
        public TransportLibDm Parent { get; set; }
        public string Version { get; set; }
        public string FirstVersionId { get; set; }
        public Aspect Aspect { get; set; }
        public string Description { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public string TerminalId { get; set; }
        public TerminalLibDm Terminal { get; set; }

        public virtual ICollection<TransportLibDm> Children { get; set; }
        public virtual ICollection<AttributeLibDm> Attributes { get; set; }
    }
}
