import { useTranslation } from "react-i18next";
import { useTheme } from "styled-components";
import { VisuallyHidden } from "../../../complib/accessibility";
import { Divider, Popover } from "../../../complib/data-display";
import { Box, Flexbox } from "../../../complib/layouts";
import { Text } from "../../../complib/text";
import { TerminalItem } from "../../types/TerminalItem";
import { TerminalButton } from "./TerminalButton";
import { TerminalDescription } from "./TerminalSingle";

interface TerminalCollectionProps {
  terminals: TerminalItem[];
  placement?: "left" | "right";
}

/**
 * Displays multiple terminals in a popover which is shown when clicking on this component.
 *
 * @param terminals to show inside popover
 * @param variant decides which side the popover should appear
 * @constructor
 */
export const TerminalCollection = ({ terminals, placement }: TerminalCollectionProps) => {
  const theme = useTheme();
  const { t } = useTranslation("translation", { keyPrefix: "terminals.summary" });

  return (
    <Popover placement={placement} content={<TerminalCollectionDescription terminals={terminals} />}>
      <TerminalButton variant={"large"} color={theme.tyle.color.ref.primary["40"]}>
        <VisuallyHidden>{t("open")}</VisuallyHidden>
      </TerminalButton>
    </Popover>
  );
};

interface TerminalCollectionDescriptionProps {
  terminals: TerminalItem[];
}

const TerminalCollectionDescription = ({ terminals }: TerminalCollectionDescriptionProps) => {
  const theme = useTheme();
  const { t } = useTranslation("translation", { keyPrefix: "terminals.summary" });
  const totalTerminalAmount = terminals.reduce((sum, terminal) => sum + terminal.amount, 0);

  return (
    <Box display={"flex"} gap={theme.tyle.spacing.l} flexDirection={"column"} maxWidth={"250px"}>
      <Text variant={"title-small"}>{t("title")}</Text>
      <Box display={"flex"} gap={theme.tyle.spacing.l} flexDirection={"column"} maxHeight={"250px"} overflow={"auto"}>
        {terminals.map((x) => (
          <TerminalDescription key={x.name} name={x.name} amount={x.amount} color={x.color} direction={x.direction} />
        ))}
      </Box>
      <Divider />
      <Flexbox gap={theme.tyle.spacing.base} justifyContent={"space-between"}>
        <Text variant={"body-medium"}>{t("total")}</Text>
        <Text variant={"body-medium"}>{totalTerminalAmount}</Text>
      </Flexbox>
    </Box>
  );
};
