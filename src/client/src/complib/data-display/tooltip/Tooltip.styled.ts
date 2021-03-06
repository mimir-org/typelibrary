import { motion } from "framer-motion";
import styled from "styled-components/macro";
import { sizingMixin, translucify } from "../../mixins";
import { Sizing } from "../../props";

export type TooltipContentProps = Sizing;

const TooltipContent = styled.div<TooltipContentProps>`
  padding: ${(props) => props.theme.tyle.spacing.base} ${(props) => props.theme.tyle.spacing.l};
  border-radius: ${(props) => props.theme.tyle.border.radius.large};
  background-color: ${(props) => translucify(props.theme.tyle.color.sys.primary.base, 0.9)};
  color: ${(props) => props.theme.tyle.color.sys.primary.on};
  box-shadow: ${(props) => props.theme.tyle.shadow.small};
  ${sizingMixin};
`;

export const MotionTooltipContent = motion(TooltipContent);
