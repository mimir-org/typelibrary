import { motion } from "framer-motion";
import { ButtonHTMLAttributes, ElementType } from "react";
import styled, { css } from "styled-components/macro";
import { flexMixin, focus, spacingMixin } from "../mixins";
import { Flex, Polymorphic, Spacing } from "../props";
import { filledButton } from "./variants/filledButton";
import { outlinedButton } from "./variants/outlinedButton";
import { textButton } from "./variants/textButton";

export type ButtonContainerProps = Flex &
  Spacing &
  Polymorphic<ElementType> &
  ButtonHTMLAttributes<HTMLButtonElement> & {
    variant?: "filled" | "outlined" | "text";
    iconPlacement?: "left" | "right";
    iconOnly?: boolean;
  };

export const ButtonContainer = styled.button<ButtonContainerProps>`
  display: inline-flex;
  justify-content: center;
  align-items: center;
  gap: ${(props) => props.theme.tyle.spacing.s};
  flex-direction: ${(props) => props.iconPlacement === "left" && "row-reverse"};

  white-space: nowrap;
  text-decoration: none;

  font: ${(props) => props.theme.tyle.typography.sys.roles.label.large.font};
  line-height: ${(props) => props.theme.tyle.typography.sys.roles.label.large.lineHeight};
  letter-spacing: ${(props) => props.theme.tyle.typography.sys.roles.label.large.letterSpacing};

  height: 32px;
  width: fit-content;
  min-width: 70px;
  padding: ${(props) => props.theme.tyle.spacing.base} ${(props) => props.theme.tyle.spacing.xl};
  border-radius: ${(props) => props.theme.tyle.border.radius.medium};

  :hover {
    cursor: pointer;
  }

  :disabled {
    cursor: not-allowed;
  }

  img,
  svg {
    max-width: 24px;
    max-height: 24px;
  }

  ${focus};

  ${({ variant, ...props }) => {
    const {
      color: { sys },
    } = props.theme.tyle;

    switch (variant) {
      case "filled": {
        return filledButton(sys);
      }
      case "outlined": {
        return outlinedButton(sys);
      }
      case "text": {
        return textButton(sys);
      }
    }
  }};

  ${({ iconOnly, ...props }) =>
    iconOnly &&
    css`
      padding: ${props.theme.tyle.spacing.xs};
      min-width: revert;
      width: 24px;
      height: 24px;

      img,
      svg {
        max-width: 18px;
        max-height: 18px;
      }
    `};

  ${flexMixin};
  ${spacingMixin};
`;

ButtonContainer.defaultProps = {
  variant: "filled",
};

/**
 * An animation wrapper for the ButtonContainer component
 *
 * @see https://github.com/framer/motion
 */
export const MotionButtonContainer = motion(ButtonContainer);
