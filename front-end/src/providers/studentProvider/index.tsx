"use client";
import React, { useReducer, useCallback, useMemo } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import {
  StudentProfileStateContext,
  StudentProfileActionContext,
  STUDENT_PROFILE_INITIAL_STATE,
  IStudentActionContext,
} from "./context";
import {
  getProfilePending,
  getProfileSuccess,
  getProfileError,
  updateProfilePending,
  updateProfileSuccess,
  updateProfileError,
} from "./actions";
import { studentProfileReducer } from "./reducer";
import { IStudent } from "../types";

interface StudentProfileProviderProps {
  children: React.ReactNode;
}

export const StudentProfileProvider = ({ children }: StudentProfileProviderProps) => {
  const [state, dispatch] = useReducer(studentProfileReducer, STUDENT_PROFILE_INITIAL_STATE);

  const getProfile = useCallback(async () => {
    try {
      dispatch(getProfilePending());
      const { data } = await axiosInstance.get("/services/app/Student/GetStudentProfile");
      dispatch(getProfileSuccess(data.result));
    } catch (error: unknown) {
      if (error && typeof error === 'object' && 'message' in error) {
        dispatch(getProfileError((error as { message?: string }).message || "Failed to fetch profile"));
      } else {
        dispatch(getProfileError("Failed to fetch profile"));
      }
    }
  }, []);

  const updateProfile = useCallback(async (data: Partial<IStudent>) => {
    try {
      dispatch(updateProfilePending());
      const { data: updated } = await axiosInstance.put("/services/app/Student/UpdateStudentProfile", data);
      dispatch(updateProfileSuccess(updated.result));
    } catch (error: unknown) {
      if (error && typeof error === 'object' && 'message' in error) {
        dispatch(updateProfileError((error as { message?: string }).message || "Failed to update profile"));
      } else {
        dispatch(updateProfileError("Failed to update profile"));
      }
    }
  }, []);

  const setProfile = useCallback((profile: IStudent | null) => {
    dispatch(getProfileSuccess(profile as IStudent));
  }, []);

  const resetProfile = useCallback(() => {
    dispatch(getProfileSuccess(null));
  }, []);

  const actions = useMemo<IStudentActionContext>(
    () => ({ getProfile, updateProfile, setProfile, resetProfile }),
    [getProfile, updateProfile, setProfile, resetProfile]
  );

  return (
    <StudentProfileStateContext.Provider value={state}>
      <StudentProfileActionContext.Provider value={actions}>
        {children}
      </StudentProfileActionContext.Provider>
    </StudentProfileStateContext.Provider>
  );
};
