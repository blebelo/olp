import axios from "axios";

export const axiosInstance = () => {
  const token = typeof window !== 'undefined' ? sessionStorage.getItem('token') : null;
  const baseURL = process.env.NEXT_PUBLIC_API_LINK;

  return axios.create({
    baseURL: baseURL,
    headers: {
      "Content-Type": "application/json",
      ...(token ? { Authorization: `${token}` } : {}),
    },
  });
};