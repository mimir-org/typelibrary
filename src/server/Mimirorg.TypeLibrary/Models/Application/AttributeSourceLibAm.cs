using System.ComponentModel.DataAnnotations;

namespace Mimirorg.TypeLibrary.Models.Application
{
    public class AttributeSourceLibAm
    {
        [Required]
        public string Name { get; set; }

        public ICollection<string> ContentReferences { get; set; }
        public string Description { get; set; }
    }
}