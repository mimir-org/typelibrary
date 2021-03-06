import { ConnectorDirection, NodeTerminalLibAm, TerminalLibCm } from "@mimirorg/typelibrary-types";
import { TerminalItem } from "../../types/TerminalItem";

export const getTerminalItemsFromFormData = (formTerminals: NodeTerminalLibAm[], sourceTerminals?: TerminalLibCm[]) => {
  if (!sourceTerminals || sourceTerminals.length < 1) {
    return [];
  }

  const terminalItems: TerminalItem[] = [];

  formTerminals.forEach((formTerminal) => {
    const sourceTerminal = sourceTerminals.find((x) => x.id === formTerminal.terminalId);

    sourceTerminal &&
      terminalItems.push({
        name: sourceTerminal.name,
        color: sourceTerminal.color,
        amount: formTerminal.quantity,
        direction: ConnectorDirection[formTerminal.connectorDirection] as keyof typeof ConnectorDirection,
      });
  });

  return terminalItems;
};
