﻿using Mimirorg.Common.Enums;
using Newtonsoft.Json;

namespace Mimirorg.TypeLibrary.Models.Data
{
    public class RdsLibDm
    {
        public string Id { get; set; }
        public string RdsCategoryId { get; set; }
        public RdsCategoryLibDm RdsCategory { get; set; }
        public string Name { get; set; }
        public string Iri { get; set; }
        public string Code { get; set; }
        
        public Aspect Aspect { get; set; }

        [JsonIgnore]
        public ICollection<LibraryTypeLibDm> LibraryTypes { get; set; }
    }
}
