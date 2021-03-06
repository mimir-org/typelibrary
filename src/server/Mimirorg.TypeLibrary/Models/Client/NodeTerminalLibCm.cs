using Mimirorg.TypeLibrary.Enums;

namespace Mimirorg.TypeLibrary.Models.Client
{
    public class NodeTerminalLibCm
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public ConnectorDirection ConnectorDirection { get; set; }
        public TerminalLibCm Terminal { get; set; }
        public string Kind => nameof(NodeTerminalLibCm);
    }
}