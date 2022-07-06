import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { useTheme } from "styled-components";
import { TextResources } from "../../../assets/text";
import { Button } from "../../../complib/buttons";
import { Form, FormErrorBanner, FormField, FormFieldset, FormHeader } from "../../../complib/form";
import { Input } from "../../../complib/inputs";
import { MotionFlexbox } from "../../../complib/layouts";
import { MotionText, Text } from "../../../complib/text";
import { getValidationStateFromServer } from "../../../data/helpers/getValidationStateFromServer";
import { useCreateUser } from "../../../data/queries/auth/queriesUser";
import { useValidationFromServer } from "../../../hooks/useValidationFromServer";
import { MimirorgUserAm } from "../../../models/auth/application/mimirorgUserAm";
import { MotionLogo } from "../../common/Logo";
import { UnauthenticatedFormContainer } from "../styled/UnauthenticatedForm";
import { RegisterFinalize } from "./components/RegisterFinalize";
import { RegisterProcessing } from "./components/RegisterProcessing";

export const Register = () => {
  const theme = useTheme();
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors },
  } = useForm<MimirorgUserAm>();
  const createUserMutation = useCreateUser();
  const validationState = getValidationStateFromServer<MimirorgUserAm>(createUserMutation.error);
  useValidationFromServer<MimirorgUserAm>(setError, validationState?.errors);

  return (
    <UnauthenticatedFormContainer>
      {createUserMutation.isLoading && <RegisterProcessing />}
      {createUserMutation.isSuccess && <RegisterFinalize qrCodeBase64={createUserMutation?.data?.code} />}
      {!createUserMutation.isSuccess && !createUserMutation.isLoading && (
        <Form onSubmit={handleSubmit((data) => createUserMutation.mutate(data))}>
          <MotionLogo layout width={"100px"} height={"50px"} inverse alt="" />
          <FormHeader title={TextResources.REGISTER_TITLE} subtitle={TextResources.REGISTER_DESCRIPTION} />

          {createUserMutation.isError && <FormErrorBanner>{TextResources.REGISTER_ERROR}</FormErrorBanner>}

          <FormFieldset>
            <FormField label={TextResources.REGISTER_EMAIL} error={errors.email}>
              <Input
                id="email"
                type="email"
                placeholder={TextResources.FORMS_PLACEHOLDER_EMAIL}
                {...register("email", { required: true })}
              />
            </FormField>

            <FormField label={TextResources.REGISTER_FIRSTNAME} error={errors.firstName}>
              <Input
                id="firstName"
                placeholder={TextResources.FORMS_PLACEHOLDER_FIRSTNAME}
                {...register("firstName", { required: true })}
              />
            </FormField>

            <FormField label={TextResources.REGISTER_LASTNAME} error={errors.lastName}>
              <Input
                id="lastName"
                placeholder={TextResources.FORMS_PLACEHOLDER_LASTNAME}
                {...register("lastName", { required: true })}
              />
            </FormField>

            <FormField label={TextResources.REGISTER_PHONE} error={errors.phoneNumber}>
              <Input id="phoneNumber" type="tel" {...register("phoneNumber", { required: false })} />
            </FormField>

            <FormField label={TextResources.REGISTER_PASSWORD} error={errors.password}>
              <Input
                id="password"
                type="password"
                placeholder={TextResources.FORMS_PLACEHOLDER_PASSWORD}
                {...register("password", { required: true })}
              />
            </FormField>

            <FormField label={TextResources.REGISTER_CONFIRM_PASSWORD} error={errors.confirmPassword}>
              <Input
                id="confirmPassword"
                type="password"
                placeholder={TextResources.FORMS_PLACEHOLDER_PASSWORD}
                {...register("confirmPassword", { required: true })}
              />
            </FormField>

            <MotionText color={theme.tyle.color.sys.surface.variant.on} layout={"position"} as={"i"}>
              {TextResources.FORMS_REQUIRED_DESCRIPTION}
            </MotionText>
          </FormFieldset>

          <MotionFlexbox layout flexDirection={"column"} alignItems={"center"} gap={theme.tyle.spacing.xxl}>
            <Button type={"submit"}>{TextResources.REGISTER_SUBMIT}</Button>
            <Text color={theme.tyle.color.sys.surface.variant.on}>
              {TextResources.REGISTER_IS_REGISTERED} <Link to="/">{TextResources.REGISTER_LOGIN_LINK}</Link>
            </Text>
          </MotionFlexbox>
        </Form>
      )}
    </UnauthenticatedFormContainer>
  );
};
