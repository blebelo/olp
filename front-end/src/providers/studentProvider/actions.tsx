import { createAction } from "redux-actions";
import { IStudentStateContext } from "./context";
import { IStudent } from "../types";

export enum StudentActionEnums {
  getProfilePending = "GET_PROFILE_PENDING",
  getProfileSuccess = "GET_PROFILE_SUCCESS",
  getProfileError = "GET_PROFILE_ERROR",

  updateProfilePending = "UPDATE_PROFILE_PENDING",
  updateProfileSuccess = "UPDATE_PROFILE_SUCCESS",
  updateProfileError = "UPDATE_PROFILE_ERROR",
}

export const getProfilePending = createAction<IStudentStateContext>(
  StudentActionEnums.getProfilePending,
  () => ({ isPending: true, isSuccess: false, isError: false, error: null })
);

export const getProfileSuccess = createAction<
  IStudentStateContext,
  IStudent | null
>(
  StudentActionEnums.getProfileSuccess,
  (profile: IStudent | null) => ({
    isPending: false,
    isSuccess: true,
    isError: false,
    profile,
    error: null
  })
);

export const getProfileError = createAction<IStudentStateContext, string>(
  StudentActionEnums.getProfileError,
  (error: string) => ({
    isPending: false,
    isSuccess: false,
    isError: true,
    profile: undefined,
    error
  })
);

export const updateProfilePending = createAction<IStudentStateContext>(
  StudentActionEnums.updateProfilePending,
  () => ({ isPending: true, isSuccess: false, isError: false, error: null })
);

export const updateProfileSuccess = createAction<
  IStudentStateContext,
  IStudent
>(
  StudentActionEnums.updateProfileSuccess,
  (profile: IStudent) => ({
    isPending: false,
    isSuccess: true,
    isError: false,
    profile,
    error: null
  })
);

export const updateProfileError = createAction<IStudentStateContext, string>(
  StudentActionEnums.updateProfileError,
  (error: string) => ({
    isPending: false,
    isSuccess: false,
    isError: true,
    error
  })
);
