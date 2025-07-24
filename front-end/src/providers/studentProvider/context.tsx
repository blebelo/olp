"use client";
import { createContext } from "react";
import { IStudent } from "../types";

export interface IStudentStateContext {
  isPending: boolean;
  isSuccess: boolean;
  isError: boolean;
  profile?: IStudent | null;
  error?: string | null;
}

export interface IStudentActionContext {
  getProfile: () => Promise<void>;
  updateProfile: (data: Partial<IStudent>) => Promise<void>;
  setProfile: (profile: IStudent | null) => void;
  resetProfile: () => void;
}

export const STUDENT_PROFILE_INITIAL_STATE: IStudentStateContext = {
  isPending: false,
  isSuccess: false,
  isError: false,
  profile: null,
  error: null,
};

export const StudentProfileStateContext =
  createContext<IStudentStateContext>(STUDENT_PROFILE_INITIAL_STATE);

export const StudentProfileActionContext =
  createContext<IStudentActionContext | undefined>(undefined);
