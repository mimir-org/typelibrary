﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TypeLibrary.Models.Models.Application
{
    public class UnitAm
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual string Description { get; set; }
        public string Iri { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}