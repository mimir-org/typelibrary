﻿namespace Mimirorg.TypeLibrary.Models.Client
{
    public class AttributePredefinedLibCm
    {
        public string Key { get; set; }
        public virtual Dictionary<string, bool> Values { get; set; }
        public bool IsMultiSelect { get; set; }
    }
}