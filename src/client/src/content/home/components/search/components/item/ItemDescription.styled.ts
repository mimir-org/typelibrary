import styled from "styled-components/macro";

export const ItemDescriptionContainer = styled.button`
  border: 0;
  background-color: transparent;
  text-align: start;

  display: flex;
  flex-direction: column;
  gap: ${(props) => props.theme.tyle.spacing.small};

  margin-right: auto;

  min-width: 200px;
  max-width: 65ch;

  :hover {
    cursor: pointer;
  }
`;
