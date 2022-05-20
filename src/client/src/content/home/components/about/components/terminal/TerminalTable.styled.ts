import styled from "styled-components/macro";
import { getTextRole } from "../../../../../../complib/mixins";

export const TerminalTableContainer = styled.table`
  border-collapse: collapse;
`;

export const TerminalTableHeader = styled.th`
  border: 1px solid ${(props) => props.theme.tyle.color.outline.base};
  padding: ${(props) => props.theme.tyle.spacing.xs};

  ${getTextRole("label-large")};

  background-color: ${(props) => props.theme.tyle.color.secondary.base};
  color: ${(props) => props.theme.tyle.color.secondary.on};
`;

export const TerminalTableData = styled.td`
  border: 1px solid ${(props) => props.theme.tyle.color.outline.base};
  padding: ${(props) => props.theme.tyle.spacing.xs};

  ${getTextRole("body-medium")};

  background-color: ${(props) => props.theme.tyle.color.surface.base};
  color: ${(props) => props.theme.tyle.color.surface.on};
`;