import { PurposeLibCm } from "@mimirorg/typelibrary-types";
import { apiClient } from "../apiClient";

const _basePath = "librarypurpose";

export const apiPurpose = {
  getPurposes() {
    return apiClient.get<PurposeLibCm[]>(_basePath).then((r) => r.data);
  },
};
