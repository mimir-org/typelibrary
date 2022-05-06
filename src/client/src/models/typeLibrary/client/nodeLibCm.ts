import { Aspect } from "../enums/aspect";
import { State } from "../enums/state";
import { InterfaceLibCm } from "./interfaceLibCm";
import { BlobLibCm } from "./blobLibCm";
import { AttributeAspectLibCm } from "./attributeAspectLibCm";
import { AttributeLibCm } from "./attributeLibCm";
import { NodeTerminalLibCm } from "./nodeTerminalLibCm";
import { SimpleLibCm } from "./simpleLibCm";
import { SelectedAttributePredefinedLibCm } from "./selectedAttributePredefinedLibCm";

export interface NodeLibCm {
  id: string;
  iri: string;
  name: string;
  rdsId: string;
  rdsName: string;
  purposeId: string;
  purposeName: string;
  parentId: string;
  parent: InterfaceLibCm;
  version: string;
  firstVersionId: string;
  aspect: Aspect;
  state: State;
  companyId: number;
  description: string;
  blobId: string;
  blob: BlobLibCm;
  attributeAspectId: string;
  attributeAspect: AttributeAspectLibCm;
  updatedBy: string;
  updated: string | null;
  created: string;
  createdBy: string;
  attributes: AttributeLibCm[];
  nodeTerminals: NodeTerminalLibCm[];
  simples: SimpleLibCm[];
  selectedAttributePredefined: SelectedAttributePredefinedLibCm[];
  kind: string;
}
