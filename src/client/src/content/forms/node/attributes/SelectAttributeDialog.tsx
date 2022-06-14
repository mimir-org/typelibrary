import { DialogClose } from "@radix-ui/react-dialog";
import { PlusSm } from "@styled-icons/heroicons-outline";
import { useState } from "react";
import { useTheme } from "styled-components/macro";
import { TextResources } from "../../../../assets/text";
import { Button } from "../../../../complib/buttons";
import { Input } from "../../../../complib/inputs";
import { Box } from "../../../../complib/layouts";
import { Dialog } from "../../../../complib/overlays";
import { AttributeInfoCheckbox } from "../../../home/components/about/components/attribute/AttributeInfoCheckbox";
import { AttributeItem } from "../../../home/types/AttributeItem";
import { filterAttributeItem, onSelectionChange } from "./SelectAttributeDialog.helpers";
import { SelectContainer } from "./SelectAttributeDialog.styled";

interface SelectAttributeDialogProps {
  attributes: AttributeItem[];
  onAdd: (attributeIds: string[]) => void;
}

/**
 * Component which shows a searchable dialog of attributes which from the user can select.
 *
 * @param attributes which the user can select from
 * @param onAdd actions to take when user pressed the add button
 * @constructor
 */
export const SelectAttributeDialog = ({ attributes, onAdd }: SelectAttributeDialogProps) => {
  const theme = useTheme();
  const [searchQuery, setSearchQuery] = useState("");
  const [selected, setSelected] = useState<string[]>([]);

  const onAddAttributes = () => {
    onAdd(selected);
    setSelected([]);
    setSearchQuery("");
  };

  return (
    <Dialog
      title={TextResources.ATTRIBUTE_DIALOG_TITLE}
      description={TextResources.ATTRIBUTE_DIALOG_DESCRIPTION}
      content={
        <Box display={"flex"} flexDirection={"column"} gap={theme.tyle.spacing.medium} overflow={"auto"}>
          <Input
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            placeholder={TextResources.ATTRIBUTE_DIALOG_FILTER}
          />
          <SelectContainer>
            <Box
              display={"flex"}
              flexWrap={"wrap"}
              justifyContent={"center"}
              gap={theme.tyle.spacing.medium}
              height={"fit-content"}
              width={"100%"}
            >
              {attributes
                .filter((x) => filterAttributeItem(x, searchQuery))
                .map((a, i) => (
                  <AttributeInfoCheckbox
                    key={i}
                    checked={selected.includes(a.id)}
                    onClick={() => onSelectionChange(a.id, selected, setSelected)}
                    {...a}
                  />
                ))}
            </Box>
          </SelectContainer>
          <DialogClose asChild>
            <Button onClick={onAddAttributes} disabled={selected.length < 1}>
              {TextResources.ATTRIBUTE_DIALOG_ADD}
            </Button>
          </DialogClose>
        </Box>
      }
    >
      <Button icon={<PlusSm />} iconOnly>
        {TextResources.ATTRIBUTE_ADD}
      </Button>
    </Dialog>
  );
};
