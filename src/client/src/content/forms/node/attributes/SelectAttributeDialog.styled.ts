import styled from "styled-components/macro";
import { hideScrollbar } from "../../../../complib/mixins";

export const SelectContainer = styled.div`
  display: flex;
  flex-wrap: wrap;
  align-content: start;
  justify-content: center;
  gap: ${(props) => props.theme.tyle.spacing.xl};

  height: 520px;
  max-width: 650px;

  padding: ${(props) => props.theme.tyle.spacing.xs};
  padding-bottom: ${(props) => props.theme.tyle.spacing.xl};

  // Fade bottom of container
  mask-image: linear-gradient(to bottom, black 93%, transparent 100%);

  // Hidden scrollbar
  overflow: auto;
  ${hideScrollbar};
`;
