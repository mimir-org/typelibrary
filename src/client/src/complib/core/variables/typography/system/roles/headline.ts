import { typeScaleSystem } from "../typeScaleSystem";
import { typefaceReference } from "../../reference/typefaceReference";
import { math } from "polished";
import { NominalScale } from "../../types";
import { typeScaleReference } from "../../reference/typeScaleReference";

export const headline: NominalScale = {
  large: {
    tracking: 0,
    size: typeScaleSystem.size.p4,
    family: typefaceReference.brand,
    weight: typefaceReference.weights.normal,
    lineHeight: typeScaleSystem.lineHeight.p4,
    letterSpacing: math(`0 / ${typeScaleReference.size.p4} * 1rem`),
    font: `${typefaceReference.weights.normal} ${typeScaleSystem.size.p4} ${typefaceReference.brand}`,
  },
  medium: {
    tracking: 0,
    size: typeScaleSystem.size.p3,
    family: typefaceReference.brand,
    weight: typefaceReference.weights.normal,
    lineHeight: typeScaleSystem.lineHeight.p3,
    letterSpacing: math(`0 / ${typeScaleReference.size.p3} * 1rem`),
    font: `${typefaceReference.weights.normal} ${typeScaleSystem.size.p3} ${typefaceReference.brand}`,
  },
  small: {
    tracking: 0,
    size: typeScaleSystem.size.p2,
    family: typefaceReference.brand,
    weight: typefaceReference.weights.normal,
    lineHeight: typeScaleSystem.lineHeight.p2,
    letterSpacing: math(`0 / ${typeScaleReference.size.p2} * 1rem`),
    font: `${typefaceReference.weights.normal} ${typeScaleSystem.size.p2} ${typefaceReference.brand}`,
  },
}