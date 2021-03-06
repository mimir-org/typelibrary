import { useEffect } from "react";
import { Path, UseFormSetError } from "react-hook-form";

/**
 * If any errors present it will combine errors received with the error structure in react-hook-form
 * @param setError function with puts a given error into a structure where it can be consumed
 * @param errors to be placed in react-hook-form error-structure
 */
export function useValidationFromServer<T>(setError: UseFormSetError<T>, errors?: Record<keyof T, string[]>) {
  useEffect(() => {
    if (errors) {
      Object.keys(errors).forEach((propertyName) => {
        setError(propertyName as Path<T>, {
          type: "server",
          message: errors[propertyName as keyof T].join(". "),
        });
      });
    }
  }, [errors, setError]);
}
