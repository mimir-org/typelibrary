import { AxiosRequestConfig } from "axios";
import { getToken } from "../../../utils/token";

/**
 * This middleware checks if there's an access token available in localstorage,
 * and appends it to the request headers if available.
 *
 * @param config
 */
export async function injectBearerToken(config: AxiosRequestConfig) {
  const token = getToken();

  if (token?.secret && config.headers) {
    config.headers["Authorization"] = `Bearer ${token.secret}`;
  }

  return config;
}
