using System.ComponentModel.DataAnnotations;
using Mimirorg.TypeLibrary.Enums;
using Mimirorg.TypeLibrary.Extensions;
using TypeScriptBuilder;

namespace Mimirorg.TypeLibrary.Models.Application
{
    public class InterfaceLibAm
    {
        [Required]
        public string Name { get; set; } //exception

        [Required]
        public string RdsName { get; set; } //exception

        [Required]
        public string RdsCode { get; set; } //exception

        [Required]
        public string PurposeName { get; set; } //minor version increase

        [Required]
        public Aspect Aspect { get; set; } //exception

        [Required]
        public int CompanyId { get; set; } //minor version increase

        [Required]
        public string TerminalId { get; set; } //exception

        public ICollection<string> AttributeIdList { get; set; } //removal = exception, add = major version increase
        public ICollection<string> ContentReferences { get; set; } //minor version increase
        public string Description { get; set; } //minor version increase
        public string ParentId { get; set; } //exception

        [TSExclude]
        public string Version { get; set; } = "1.0";

        [TSExclude]
        public string FirstVersionId { get; set; }

        [TSExclude]
        public string Id => $"{Name}-{RdsCode}-{Aspect}-{Version}".CreateMd5();
    }
}