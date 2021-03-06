import { ComponentStory } from "@storybook/react";
import { Checkbox } from "../../../complib/inputs/checkbox/Checkbox";
import { Flexbox } from "../../../complib/layouts";
import { UserMenu } from "./UserMenu";

export default {
  title: "Content/Header/UserMenu",
  component: UserMenu,
};

const Template: ComponentStory<typeof UserMenu> = (args) => <UserMenu {...args} />;

export const Default = Template.bind({});
Default.args = {
  name: "Threepwood",
  children: (
    <>
      <Flexbox as={"label"} alignItems={"center"} gap={"4px"}>
        <Checkbox />
        Toggle dark mode
      </Flexbox>
      <Flexbox as={"label"} alignItems={"center"} gap={"4px"}>
        <Checkbox />
        Go to admin menu
      </Flexbox>
      <Flexbox as={"label"} alignItems={"center"} gap={"4px"}>
        <Checkbox />
        Logout
      </Flexbox>
    </>
  ),
};
