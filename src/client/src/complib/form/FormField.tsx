import { useTheme } from "styled-components";
import { PropsWithChildren } from "react";
import { MotionFlexbox } from "../layouts";
import { MotionText, Text } from "../text";

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
export const FormField = ({ label, error, children }: PropsWithChildren<FormFieldProps>) => {
  const theme = useTheme();

  return (
    <MotionFlexbox layout={"position"} flexDirection={"column"} gap={theme.tyle.spacing.xs}>
      <Text as={"label"} variant={"label-large"}>
        {label}
      </Text>
      {children}
      {error && error.message && (
        <MotionText color={theme.tyle.color.error.base} {...theme.tyle.animation.fade}>
          {error.message}
        </MotionText>
      )}
    </MotionFlexbox>
  );
};
