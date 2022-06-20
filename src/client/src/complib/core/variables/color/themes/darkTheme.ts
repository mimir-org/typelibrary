import { colorReference } from "../reference/colorReference";
import { ColorTheme } from "../types/colorTheme";

export const darkTheme: ColorTheme = {
  primary: {
    base: colorReference.primary[80],
    on: colorReference.primary[20],
  },
  secondary: {
    base: colorReference.secondary[80],
    on: colorReference.secondary[0],
    container: {
      base: colorReference.secondary[40],
      on: colorReference.secondary[0]
    }
  },
  tertiary: {
    base: colorReference.tertiary[80],
    on: colorReference.primary[20],
    container: {
      base: colorReference.tertiary[40],
      on: colorReference.primary[70]
    }
  },
  error: {
    base: colorReference.error[80],
    on: colorReference.error[20],
  },
  outline: {
    base: colorReference.neutralVariant[60]
  },
  background: {
    base: colorReference.neutral[10],
    on: colorReference.neutral[99],
    inverse: {
      base: colorReference.neutral[10],
      on: colorReference.neutral[99],
    },
  },
  surface: {
    base: colorReference.neutral[20],
    on: colorReference.neutral[80],
    variant: {
      base: colorReference.neutralVariant[30],
      on: colorReference.neutralVariant[80],
    },
    inverse: {
      base: colorReference.neutral[99],
      on: colorReference.neutral[10],
    },
    tint: {
      base: colorReference.primary[80]
    }
  },
  shadow: {
    base: colorReference.neutral[0],
  }
};