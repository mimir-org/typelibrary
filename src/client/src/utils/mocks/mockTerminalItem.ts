import { faker } from "@faker-js/faker";
import { TerminalItem } from "../../content/types/TerminalItem";
import { mockAttributeItem } from "./mockAttributeItem";

export const mockTerminalItem = (): TerminalItem => ({
  name: `Terminal ${faker.random.alpha({ count: 3, casing: "upper" })}`,
  color: faker.internet.color(),
  amount: parseInt(faker.random.numeric(1)),
  direction: faker.helpers.arrayElement(["Input", "Output", "Bidirectional"]),
  attributes: [...Array(7)].map((_) => mockAttributeItem()),
});
