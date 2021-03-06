import { ComponentMeta, ComponentStory } from "@storybook/react";
import { mockNodeItem } from "../../../../../../utils/mocks";
import { NodePanel } from "./NodePanel";

export default {
  title: "Content/Explore/About/Panels/NodePanel",
  component: NodePanel,
  args: {
    ...mockNodeItem(),
  },
} as ComponentMeta<typeof NodePanel>;

const Template: ComponentStory<typeof NodePanel> = (args) => <NodePanel {...args} />;

export const Default = Template.bind({});
