import { NodeTerminalLibCm } from "../../models/tyle/client/nodeTerminalLibCm";
import { TerminalItem } from "../../content/home/types/TerminalItem";
import { ConnectorDirection } from "../../models/tyle/enums/connectorDirection";
import { mapAttributeLibsToAttributeItems } from "./mapAttributeLibsToAttributeItems";
import { sortAttributes } from "../sorters";

export const mapNodeTerminalLibsToLibraryItems = (nodeTerminalLibs: NodeTerminalLibCm[]): TerminalItem[] =>
  nodeTerminalLibs.map((x) => ({
    name: x.terminal.name,
    color: x.terminal.color,
    amount: x.number,
    direction: ConnectorDirection[x.connectorDirection] as keyof typeof ConnectorDirection,
    attributes: sortAttributes(mapAttributeLibsToAttributeItems(x.terminal.attributes)),
  }));