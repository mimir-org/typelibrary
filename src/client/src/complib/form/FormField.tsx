import { PropsWithChildren } from "react";
import { MotionFlexbox } from "../layouts";
import { MotionText, Text } from "../text";
import { ANIMATION, theme } from "../core";

interface FormFieldProps {
  label?: string;
  error?: { message?: string };
}

/**
 * A component for wrapping form inputs with a label and an error message
 * @param label describing the input
 * @param error message for the given input
 * @param children
 * @constructor
 */
export const FormField = ({ label, error, children }: PropsWithChildren<FormFieldProps>) => (
  <MotionFlexbox layout={"position"} flexDirection={"column"} gap={theme.spacing.xs}>
    <Text as={"label"} fontWeight={theme.font.weights.bold}>
      {label}
    </Text>
    {children}
    {error && error.message && (
      <MotionText color={theme.color.error.base} {...ANIMATION.VARIANTS.FADE}>
        {error.message}
      </MotionText>
    )}
  </MotionFlexbox>
);
