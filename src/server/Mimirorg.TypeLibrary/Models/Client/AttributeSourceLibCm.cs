namespace Mimirorg.TypeLibrary.Models.Client
{
    public class AttributeSourceLibCm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Iri { get; set; }
        public ICollection<string> ContentReferences { get; set; }
        public string Description { get; set; }
        public string Kind => nameof(AttributeSourceLibCm);
    }
}