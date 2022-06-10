import { TerminalItem } from "../../content/home/types/TerminalItem";
import { NodeTerminalLibCm } from "../../models/tyle/client/nodeTerminalLibCm";
import { ConnectorDirection } from "../../models/tyle/enums/connectorDirection";
import { sortAttributes } from "../sorters";
import { mapAttributeLibCmsToAttributeItems } from "./mapAttributeLibCmToAttributeItem";

export const mapNodeTerminalLibCmToTerminalItem = (terminal: NodeTerminalLibCm): TerminalItem => ({
  name: terminal.terminal.name,
  color: terminal.terminal.color,
  amount: terminal.quantity,
  direction: ConnectorDirection[terminal.connectorDirection] as keyof typeof ConnectorDirection,
  attributes: sortAttributes(mapAttributeLibCmsToAttributeItems(terminal.terminal.attributes)),
});

export const mapNodeTerminalLibCmsToTerminalItems = (terminals: NodeTerminalLibCm[]): TerminalItem[] =>
  terminals.map((x) => mapNodeTerminalLibCmToTerminalItem(x));
