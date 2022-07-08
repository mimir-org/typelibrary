import * as AlertDialogPrimitive from "@radix-ui/react-alert-dialog";
import { ReactNode } from "react";
import { VisuallyHidden } from "../../../accessibility";
import { Text } from "../../../text";
import { ConditionalWrapper } from "../../../utils";

interface DialogTitleProps {
  children: ReactNode;
  hide?: boolean;
}

export const AlertDialogTitle = ({ children, hide }: DialogTitleProps) => (
  <ConditionalWrapper condition={hide} wrapper={(c) => <VisuallyHidden asChild>{c}</VisuallyHidden>}>
    <AlertDialogPrimitive.Title asChild>
      <Text variant={"title-large"} textAlign={"center"}>
        {children}
      </Text>
    </AlertDialogPrimitive.Title>
  </ConditionalWrapper>
);
