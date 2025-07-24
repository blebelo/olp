import { createAction } from "redux-actions";
import { IInstructorStateContext } from "./context";
import { IInstructor } from "../types";

// Enum for all InstructorProfile action types
export enum InstructorActionEnums {
  getProfilePending = "GET_PROFILE_PENDING",
  getProfileSuccess = "GET_PROFILE_SUCCESS",
  getProfileError = "GET_PROFILE_ERROR",

  updateProfilePending = "UPDATE_PROFILE_PENDING",
  updateProfileSuccess = "UPDATE_PROFILE_SUCCESS",
  updateProfileError = "UPDATE_PROFILE_ERROR",
}

// Get Profile Actions
export const getProfilePending = createAction<IInstructorStateContext>(
  InstructorActionEnums.getProfilePending,
  () => ({ isPending: true, isSuccess: false, isError: false, error: null })
);

export const getProfileSuccess = createAction<
  IInstructorStateContext,
  IInstructor
>(
  InstructorActionEnums.getProfileSuccess,
  (profile: IInstructor) => ({
    isPending: false,
    isSuccess: true,
    isError: false,
    profile,
    error: null
  })
);


export const getProfileError = createAction<IInstructorStateContext, string>(
  InstructorActionEnums.getProfileError,
  (error: string) => ({
    isPending: false,
    isSuccess: false,
    isError: true,
    profile: undefined,
    error // store the error message
  })
);

// Update Profile Actions
export const updateProfilePending = createAction<IInstructorStateContext>(
  InstructorActionEnums.updateProfilePending,
  () => ({ isPending: true, isSuccess: false, isError: false, error: null })
);

export const updateProfileSuccess = createAction<
  IInstructorStateContext,
  IInstructor
>(
  InstructorActionEnums.updateProfileSuccess,
  (profile: IInstructor) => ({
    isPending: false,
    isSuccess: true,
    isError: false,
    profile,
    error: null
  })
);


export const updateProfileError = createAction<IInstructorStateContext, string>(
  InstructorActionEnums.updateProfileError,
  (error: string) => ({
    isPending: false,
    isSuccess: false,
    isError: true,
    error // store the error message
  })
);