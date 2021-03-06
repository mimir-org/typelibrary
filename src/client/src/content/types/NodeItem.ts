import { TerminalItem } from "./TerminalItem";
import { AttributeItem } from "./AttributeItem";

export interface NodeItem {
  id: string;
  name: string;
  description: string;
  img: string;
  color: string;
  tokens: string[];
  terminals: TerminalItem[];
  attributes: AttributeItem[];
}
