import { ConnectorDirection } from "../../../../../../models/tyle/enums/connectorDirection";

type Direction = keyof typeof ConnectorDirection;

export const meetsInputCriteria = (direction: Direction) => {
  return direction === "Input" || direction === "Bidirectional";
};

export const meetsOutputCriteria = (direction: Direction) => {
  return direction === "Output" || direction === "Bidirectional";
};
