import styled from "styled-components";

interface ModalContentContainerProps {
  title?: string;
  description?: string;
  color?: string;
}

export const ModalContentContainer = styled.div<ModalContentContainerProps>`
  position: relative;
  display: flex;
  flex-direction: column;
  gap: ${(props) => props.theme.typeLibrary.spacing.xs};
  min-height: 350px;
  min-width: min(500px, 100%);
  max-width: 100%;
  box-shadow: ${(props) => props.theme.typeLibrary.shadow.boxMedium};
  background-color: ${(props) => props.theme.typeLibrary.color.surface.base};
  color: ${(props) => props.theme.typeLibrary.color.surface.variant.on};
  border-radius: ${(props) => props.theme.typeLibrary.border.radius.large};
  padding: ${(props) => props.theme.typeLibrary.spacing.large};
`;

export const ModalHeaderTitle = styled.p`
  font: ${(props) => props.theme.typeLibrary.typography.headline.small.font};
  color: ${(props) => props.theme.typeLibrary.color.surface.on};
  margin: 0;
`;

export const ModalHeaderDescription = styled.p`
  font: ${(props) => props.theme.typeLibrary.typography.body.large.font};
  color: ${(props) => props.theme.typeLibrary.color.surface.variant.on};
  margin: 0;
`;
