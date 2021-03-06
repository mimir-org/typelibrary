import { ComponentStory } from "@storybook/react";
import { SearchPlaceholder } from "./SearchPlaceholder";

export default {
  title: "Content/Explore/Search/SearchPlaceholder",
  component: SearchPlaceholder,
};

const Template: ComponentStory<typeof SearchPlaceholder> = (args) => <SearchPlaceholder {...args}></SearchPlaceholder>;

export const Default = Template.bind({});
Default.args = {
  title: "We could not find what you were searching for",
  subtitle: "Search help",
  tips: [
    "Check you search for typos",
    "Use more generic search terms",
    "The item you are looking might not have been added yet",
  ],
};
