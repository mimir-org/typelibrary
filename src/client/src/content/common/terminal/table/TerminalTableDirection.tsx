import { ArrowLeft, ArrowRight, SwitchHorizontal } from "@styled-icons/heroicons-outline";
import { useTranslation } from "react-i18next";
import { useTheme } from "styled-components";
import { Td } from "../../../../complib/data-display";
import { Flexbox } from "../../../../complib/layouts";
import { TerminalItem } from "../../../types/TerminalItem";

export const TerminalTableDirection = ({ direction }: Pick<TerminalItem, "direction">) => {
  const theme = useTheme();
  const { t } = useTranslation("translation", { keyPrefix: "terminals" });
  const directionIconSize = 20;

  return (
    <Td data-label={t("templates.terminal", { object: t("direction").toLowerCase() })}>
      <Flexbox alignItems={"center"} gap={theme.tyle.spacing.base}>
        {direction === "Input" && <ArrowRight color={theme.tyle.color.sys.primary.base} size={directionIconSize} />}
        {direction === "Output" && <ArrowLeft color={theme.tyle.color.sys.primary.base} size={directionIconSize} />}
        {direction === "Bidirectional" && (
          <SwitchHorizontal color={theme.tyle.color.sys.primary.base} size={directionIconSize} />
        )}
        {direction}
      </Flexbox>
    </Td>
  );
};
