import { useTheme } from "styled-components";
import { Box } from "../../complib/layouts";
import { useGetCurrentUser } from "../../data/queries/auth/queriesUser";
import { Logo } from "./components/Logo";
import { LibraryIcon } from "../../assets/icons/modules";
import { User } from "./components/User";

export const Header = () => {
  const { data, isLoading } = useGetCurrentUser();
  const theme = useTheme();

  return (
    <Box
      as={"header"}
      display={"flex"}
      alignItems={"center"}
      justifyContent={"space-between"}
      py={theme.tyle.spacing.small}
      px={theme.tyle.spacing.large}
      height={"60px"}
      bgColor={theme.tyle.color.primary.base}
      color={theme.tyle.color.primary.on}
      boxShadow={theme.tyle.shadow.small}
      zIndex={10}
    >
      <Logo name={"Tyle"} icon={LibraryIcon} />
      {!isLoading && <User name={`${data?.firstName} ${data?.lastName}`} />}
    </Box>
  );
};
