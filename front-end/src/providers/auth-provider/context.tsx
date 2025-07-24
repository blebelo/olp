import { createContext } from "react";

export interface IUser {
    name?: string,
    surname?: string,
    userName?: string,
    email?: string,
    password?: string,
    bio?: string,
    profession?: string,
    userNameOrEmailAddress?: string,
    interests?: string; //changed to match backend
    academicLevel?: string;
}

export interface IAuthStateContext {
    isPending: boolean;
    isSuccess: boolean;
    isError: boolean; 
    user?:IUser;
}

export interface IAuthActionContext {
    registerInstructor: (user: IUser) => Promise<void>;
    registerStudent : (user: IUser) => Promise<void>;
    loginUser: (user: IUser) => Promise<void>;
}

export const INITIAL_STATE: IAuthStateContext = {
    isPending: false,
    isSuccess: false,
    isError: false,
}

export const AuthStateContext = createContext<IAuthStateContext>(INITIAL_STATE);
export const AuthActionContext = createContext<IAuthActionContext>(undefined!);