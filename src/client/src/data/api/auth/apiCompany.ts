import { apiClient } from "../apiClient";
import { MimirorgCompanyAm } from "../../../models/auth/application/mimirorgCompanyAm";
import { MimirorgCompanyCm } from "../../../models/auth/client/mimirorgCompanyCm";

const _basePath = "mimirorgcompany";

export const apiCompany = {
  getCompanies() {
    return apiClient.get<MimirorgCompanyCm[]>(_basePath).then((r) => r.data);
  },
  getCompany(id: number) {
    return apiClient.get<MimirorgCompanyCm>(`${_basePath}/${id}`).then((r) => r.data);
  },
  postCompany(item: MimirorgCompanyAm) {
    return apiClient.post<MimirorgCompanyCm>(_basePath, item).then((r) => r.data);
  },
  putCompany(id: number, item: MimirorgCompanyAm) {
    return apiClient.put<MimirorgCompanyCm>(`${_basePath}/${id}`, item).then((r) => r.data);
  },
  deleteCompany(id: number) {
    return apiClient.delete<boolean>(`${_basePath}/${id}`).then((r) => r.data);
  },
};
