import { ForwardedRef, forwardRef, InputHTMLAttributes, isValidElement, ReactElement } from "react";
import { Box } from "../../layouts";
import { Icon } from "../../media";
import { Sizing } from "../../props";
import { InputContainer, InputIconContainer } from "./Input.styled";

export type InputProps = InputHTMLAttributes<HTMLInputElement> &
  Omit<Sizing, "boxSizing"> & {
    icon?: string | ReactElement;
    iconPlacement?: "left" | "right";
  };

/**
 * A simple wrapper over the input-tag, with styling that follows library conventions.
 */
export const Input = forwardRef((props: InputProps, ref: ForwardedRef<HTMLInputElement>) => {
  const { width, maxWidth, minWidth, height, maxHeight, minHeight, icon, iconPlacement, type, ...delegated } = props;
  const IconComponent = () => (isValidElement(icon) ? icon : <Icon src={icon} alt="" />);
  const isHidden = type === "hidden";

  return (
    <Box
      display={isHidden ? "none" : undefined}
      position={"relative"}
      height={height}
      maxHeight={maxHeight}
      minHeight={minHeight}
      width={width}
      maxWidth={maxWidth}
      minWidth={minWidth}
    >
      <InputContainer ref={ref} type={type} iconPlacement={iconPlacement} {...delegated} />
      {icon && (
        <InputIconContainer iconPlacement={iconPlacement}>
          <IconComponent />
        </InputIconContainer>
      )}
    </Box>
  );
});

Input.displayName = "Input";
Input.defaultProps = {
  height: "40px",
  iconPlacement: "right",
};
