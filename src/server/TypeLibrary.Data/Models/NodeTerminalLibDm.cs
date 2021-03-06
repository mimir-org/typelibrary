using Mimirorg.TypeLibrary.Enums;

namespace TypeLibrary.Data.Models
{
    public class NodeTerminalLibDm
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public ConnectorDirection ConnectorDirection { get; set; }
        public string NodeId { get; set; }
        public NodeLibDm Node { get; set; }
        public string TerminalId { get; set; }
        public TerminalLibDm Terminal { get; set; }
    }
}