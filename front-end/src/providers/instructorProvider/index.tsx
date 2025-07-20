"use client";
import React, { useReducer, useContext, useMemo } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import {
  InstructorProfileStateContext,
  InstructorProfileActionContext,
  INSTRUCTOR_PROFILE_INITIAL_STATE,
  IInstructor,
} from "./context";
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
  const getProfile = async () => {
    dispatch(getProfilePending());
    try {
      const { data } = await axiosInstance.get("/services/app/Instructor/GetMyProfile");
      dispatch(getProfileSuccess(data.result));
    } catch (err: any) {
      const errorMsg =
        err?.response?.data?.error?.message || err?.message || "Failed to fetch instructor profile";
      dispatch(getProfileError(errorMsg));
    }
  };

  // UPDATE profile
  const updateProfile = async (updatedData: Partial<IInstructor>) => {
    dispatch(updateProfilePending());
    try {
      const { data } = await axiosInstance.put("/services/app/Instructor/UpdateMyProfile", updatedData);
      dispatch(updateProfileSuccess(data.result));
      // Clear any lingering error if update is successful
      // (Handled by updateProfileSuccess, but this is explicit)
    } catch (err: any) {
      const errorMsg =
        err?.response?.data?.error?.message || err?.message || "Failed to update instructor profile";
      dispatch(updateProfileError(errorMsg));
    }
  };

  // Set profile (for direct manipulation if needed)
  const setProfile = (profile: IInstructor | null) => {
    dispatch(getProfileSuccess(profile as IInstructor));
  };

  // Reset profile state (for logout or new login)
  const resetProfile = () => {
    dispatch(getProfileSuccess({} as IInstructor));
    dispatch(getProfileError(""));
  };

  React.useEffect(() => {
    getProfile();
  }, []);

  const actions = useMemo(() => ({ getProfile, updateProfile, setProfile, resetProfile }), []);
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