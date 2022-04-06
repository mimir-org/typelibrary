import { create } from "@storybook/theming";
import { LibraryIcon } from "../src/assets/icons/modules";

export default create({
  base: "light",
  brandImage: LibraryIcon,
  brandTitle: "Type library",
  brandUrl: "https://github.com/mimir-org/typelibrary",
});