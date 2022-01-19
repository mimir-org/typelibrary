﻿using System.ComponentModel.DataAnnotations;

namespace TypeLibrary.Models.Application
{
    public class SourceAm
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iri { get; set; }
    }
}