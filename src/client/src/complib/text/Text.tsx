import { motion } from "framer-motion";
import { ElementType } from "react";
import styled from "styled-components/macro";
import { displayMixin, ellipsisMixin, getTextRole, paletteMixin, spacingMixin, typographyMixin } from "../mixins";
import { Display, Palette, Polymorphic, Spacing, TextVariant, Typography } from "../props";
import { Ellipsis } from "../props/ellipsis";

type TextProps = Spacing &
  Pick<Palette, "color"> &
  Pick<Display, "whiteSpace" | "display"> &
  Pick<Typography, "font" | "fontSize" | "fontWeight" | "textAlign" | "textTransform" | "wordBreak"> &
  Polymorphic<ElementType> &
  TextVariant &
  Ellipsis;

/**
 * A polymorphic text component for non-heading text
 *
 * @param as element to display component as (defaults to <p>)
 * @param font overrides font of text element
 * @param fontSize overrides default size of the text element
 * @param fontWeight overrides default font-weight of the text element
 * @param color overrides default color of the text element
 * @param useEllipsis enable truncation of text
 * @param ellipsisMaxLines set how many lines to display before truncation
 * @constructor
 */
export const Text = styled.p<TextProps>`
  ${({ variant }) => getTextRole(variant)}};
  ${paletteMixin};
  ${displayMixin};
  ${spacingMixin};
  ${ellipsisMixin};
  ${typographyMixin};
`;

Text.defaultProps = {
  useEllipsis: false,
  ellipsisMaxLines: 1,
};

/**
 * An animation wrapper for the Text component
 *
 * @see https://github.com/framer/motion
 */
export const MotionText = motion(Text);
