import { ComponentMeta, ComponentStory } from "@storybook/react";
import { AttributeInfoButton } from "./AttributeInfoButton";

export default {
  title: "Content/Home/About/Attribute/AttributeInfoButton",
  component: AttributeInfoButton,
} as ComponentMeta<typeof AttributeInfoButton>;

const Template: ComponentStory<typeof AttributeInfoButton> = (args) => <AttributeInfoButton {...args} />;

export const Default = Template.bind({});
Default.args = {
  name: "Pressure, absolute",
  color: "orange",
  traits: {
    condition: "Maximum",
    qualifier: "Operating",
    source: "Calculated",
  },
};

export const Actionable = Template.bind({});
Actionable.args = {
  ...Default.args,
  actionable: true,
  actionIcon: "static/media/src/assets/icons/modules/library.svg",
  actionText: "Trigger action",
  onAction: () => alert("[STORYBOOK] AttributeDescription.Remove"),
};
