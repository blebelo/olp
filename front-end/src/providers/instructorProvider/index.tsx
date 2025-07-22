"use client";
import React, { useReducer, useContext, useMemo, useCallback } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import {
  InstructorProfileStateContext,
  InstructorProfileActionContext,
  INSTRUCTOR_PROFILE_INITIAL_STATE,
} from "./context";
import { IInstructor } from "../types";
import { InstructorProfileReducer } from "./reducer";
import {
  getProfilePending,
  getProfileSuccess,
  getProfileError,
  updateProfilePending,
  updateProfileSuccess,
  updateProfileError,
} from "./actions";

// Provider
export const InstructorProvider = ({ children }: { children: React.ReactNode }) => {
  const [state, dispatch] = useReducer(InstructorProfileReducer, INSTRUCTOR_PROFILE_INITIAL_STATE);

  // GET profile
  const getProfile = useCallback(async () => {
    dispatch(getProfilePending());
    try {
      const { data } = await axiosInstance.get("/services/app/Instructor/GetMyProfile");
      dispatch(getProfileSuccess(data.result));
    } catch (err: unknown) {
      let errorMsg = "Failed to fetch instructor profile";
      type AxiosErrorShape = {
        response?: { data?: { error?: { message?: string } } };
        message?: string;
      };
      if (typeof err === "object" && err !== null) {
        const e = err as AxiosErrorShape;
        if (e.response?.data?.error?.message) {
          errorMsg = e.response.data.error.message;
        } else if (e.message) {
          errorMsg = e.message;
        }
      }
      dispatch(getProfileError(errorMsg));
    }
  }, [dispatch]);

  // UPDATE profile
  const updateProfile = useCallback(async (updatedData: Partial<IInstructor>) => {
    dispatch(updateProfilePending());
    try {
      const { data } = await axiosInstance.put("/services/app/Instructor/UpdateMyProfile", updatedData);
      dispatch(updateProfileSuccess(data.result));
      // Clear any lingering error if update is successful
      // (Handled by updateProfileSuccess, but this is explicit)
    } catch (err: unknown) {
      let errorMsg = "Failed to update instructor profile";
      type AxiosErrorShape = {
        response?: { data?: { error?: { message?: string } } };
        message?: string;
      };
      if (typeof err === "object" && err !== null) {
        const e = err as AxiosErrorShape;
        if (e.response?.data?.error?.message) {
          errorMsg = e.response.data.error.message;
        } else if (e.message) {
          errorMsg = e.message;
        }
      }
      dispatch(updateProfileError(errorMsg));
    }
  }, [dispatch]);

  // Set profile (for direct manipulation if needed)
  const setProfile = useCallback((profile: IInstructor | null) => {
    dispatch(getProfileSuccess(profile as IInstructor));
  }, [dispatch]);

  // Reset profile state (for logout or new login)
  const resetProfile = useCallback(() => {
    dispatch(getProfileSuccess({} as IInstructor));
    dispatch(getProfileError(""));
  }, [dispatch]);

  React.useEffect(() => {
    getProfile();
  }, [getProfile]);

  const actions = useMemo(() => ({ getProfile, updateProfile, setProfile, resetProfile }), [getProfile, updateProfile, setProfile, resetProfile]);
  return (
    <InstructorProfileStateContext.Provider value={state}>
      <InstructorProfileActionContext.Provider value={actions}>
        {children}
      </InstructorProfileActionContext.Provider>
    </InstructorProfileStateContext.Provider>
  );
};

export const useInstructorProfileState = () => {
  const context = useContext(InstructorProfileStateContext);
  if (!context) {
    throw new Error("useInstructorProfileState must be used within InstructorProfileProvider");
  }
  return context;
};

export const useInstructorProfileActions = () => {
  const context = useContext(InstructorProfileActionContext);
  if (!context) {
    throw new Error("useInstructorProfileActions must be used within InstructorProfileProvider");
  }
  return context;
};