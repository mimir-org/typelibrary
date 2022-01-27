﻿using System.Collections.Generic;

namespace TypeLibrary.Models.Models.Data
{
    public class InterfaceDm : TypeDm
    {
        public string TerminalId { get; set; }
        public TerminalDm TerminalDm { get; set; }
        public ICollection<AttributeDm> AttributeList { get; set; }
    }
}
