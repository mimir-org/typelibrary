import { Aspect } from "../enums/aspect";
import { Discipline } from "../enums/discipline";
import { Select } from "../enums/select";
import { UnitLibCm } from "./unitLibCm";

export interface AttributeLibCm {
  id: string;
  parentId: string;
  parent: AttributeLibCm;
  children: AttributeLibCm[];
  name: string;
  iri: string;
  aspect: Aspect;
  discipline: Discipline;
  tags: Set<string>;
  select: Select;
  attributeQualifier: string;
  attributeSource: string;
  attributeCondition: string;
  attributeFormat: string;
  selectValues: string[];
  units: UnitLibCm[];
  description: string;
  kind: string;
}